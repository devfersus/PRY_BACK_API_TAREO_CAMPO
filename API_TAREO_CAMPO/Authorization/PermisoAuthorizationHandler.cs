using Microsoft.AspNetCore.Authorization;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using System.Security.Claims;

namespace API_TAREO_CAMPO.Authorization
{
    public class PermisoAuthorizationHandler(ITokenCache tokenCache)
        : AuthorizationHandler<PermisoRequirement>
    {
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PermisoRequirement          requirement)
        {
            var usuarioIdTexto = context.User.FindFirstValue(ClaimTypes.NameIdentifier)
                              ?? context.User.FindFirstValue("sub");

            if (usuarioIdTexto is null || !Guid.TryParse(usuarioIdTexto, out var usuarioId))
            {
                context.Fail();
                return;
            }

            var permisos = await tokenCache.ObtenerPermisosAsync(usuarioId);

            if (permisos.Contains(requirement.Clave))
                context.Succeed(requirement);
            else
                context.Fail();
        }
    }
}
