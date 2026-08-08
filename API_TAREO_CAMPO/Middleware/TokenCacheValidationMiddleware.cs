using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using System.Security.Claims;

namespace API_TAREO_CAMPO.Middleware
{
    public class TokenCacheValidationMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext ctx, ITokenCache sesionCache)
        {
            if (ctx.User.Identity?.IsAuthenticated == true)
            {
                var usuarioIdTexto = ctx.User.FindFirstValue(ClaimTypes.NameIdentifier)
                                  ?? ctx.User.FindFirstValue("sub");

                var encabezadoAuth = ctx.Request.Headers.Authorization.ToString();
                var tokenRecibido  = encabezadoAuth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
                    ? encabezadoAuth["Bearer ".Length..].Trim()
                    : null;

                if (usuarioIdTexto is null || tokenRecibido is null || !Guid.TryParse(usuarioIdTexto, out var usuarioId))
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return;
                }

                var tokenGuardado = await sesionCache.VerificarTokenAsync(usuarioId, ctx.RequestAborted);
                var tokenEsActivo = tokenGuardado == tokenRecibido;

                if (!tokenEsActivo)
                {
                    ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await ctx.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = StatusCodes.Status401Unauthorized,
                        Title  = "Sesión inválida",
                        Detail = "El token no corresponde a una sesión activa."
                    }, ctx.RequestAborted);
                    return;
                }
            }

            await next(ctx);
        }
    }
}
