using API_TAREO_CAMPO.Controllers.Core.Compra_.Scoped;
using API_TAREO_CAMPO.Controllers.Maestro.Categoria_.Scoped;
using API_TAREO_CAMPO.Controllers.Maestro.Pais_.Scoped;
using API_TAREO_CAMPO.Controllers.Maestro.Producto_.Scoped;
using API_TAREO_CAMPO.Controllers.Seguridad.Login.CasosUso.Auth.Scoped;
using API_TAREO_CAMPO.Controllers.Seguridad.Navegacion_.Scoped;
using API_TAREO_CAMPO.Filters;
using API_TAREO_CAMPO.Middleware;
using API_TAREO_CAMPO.Services;
using CORE.Infraestructura;
using MAESTRO.Infraestructura;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using SEGURIDAD.Infraestructura;
using StackExchange.Redis;
using System.Text;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<DomainExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<SeguridadDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("SeguridadDb")));

builder.Services.AddDbContext<MaestroDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("SeguridadDb")));

builder.Services.AddDbContext<CoreDBContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("SeguridadDb")));

builder.Services.AddSingleton<IConnectionMultiplexer>(
    _ => ConnectionMultiplexer.Connect(
        builder.Configuration.GetConnectionString("Redis")!)
 );

builder.Services.AgregarModuloLogin();
builder.Services.AgregarModuloNavegacion();
builder.Services.AgregarModuloPais();
builder.Services.AgregarModuloCategoria();
builder.Services.AgregarModuloProducto();
builder.Services.AgregarModuloCompra();

builder.Services.AddSingleton<IRequestGuard, RedisRequestGuard>();
builder.Services.AddScoped<EmailRequestGuardFilter>();

var jwtCfg = builder.Configuration.GetSection("Jwt");
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer           = true,
            ValidateAudience         = true,
            ValidateLifetime         = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer              = jwtCfg["Issuer"],
            ValidAudience            = jwtCfg["Audience"],
            IssuerSigningKey         = new SymmetricSecurityKey(
                                           Encoding.UTF8.GetBytes(jwtCfg["SecretKey"]!))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var seguridadDb = scope.ServiceProvider.GetRequiredService<SeguridadDBContext>();
//    seguridadDb.Database.Migrate();

//    var paisDb = scope.ServiceProvider.GetRequiredService<PaisDBContext>();
//    paisDb.Database.Migrate();
//}

app.UseSwagger();
app.MapScalarApiReference(options =>
    options.WithOpenApiRoutePattern("/swagger/v1/swagger.json"));

app.UseExceptionHandler();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthentication();
app.UseMiddleware<TokenCacheValidationMiddleware>();
app.UseAuthorization();
app.MapControllers();

app.Run();