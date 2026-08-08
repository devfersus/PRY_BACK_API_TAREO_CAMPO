using API_TAREO_CAMPO.Redis;
using API_TAREO_CAMPO.Services;
using SEGURIDAD.Login_.Web.Aplicacion.CasosUso;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Login.CasosUso.Auth.Scoped
{
    public static class LoginModuloExtensions
    {
        public static IServiceCollection AgregarModuloLogin(this IServiceCollection services)
        {
            services.AddScoped<ILoginCasoUso, LoginServicioAplicacion>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<ITokenCache, RedisTokenCache>();
            return services;
        }
    }
}
