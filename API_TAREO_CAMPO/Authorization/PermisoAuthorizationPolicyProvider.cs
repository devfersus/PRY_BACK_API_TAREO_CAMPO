using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace API_TAREO_CAMPO.Authorization
{
    /// <summary>
    /// Genera automáticamente policies de autorización de la forma "Permiso:MODULO|SUBMODULO|ACCION"
    /// sin necesidad de registrarlas estáticamente en AddAuthorization.
    /// </summary>
    public class PermisoAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        : DefaultAuthorizationPolicyProvider(options)
    {
        private const string Prefijo = "Permiso:";

        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            var existente = await base.GetPolicyAsync(policyName);
            if (existente is not null)
                return existente;

            if (policyName.StartsWith(Prefijo, StringComparison.OrdinalIgnoreCase))
            {
                var clave = policyName[Prefijo.Length..];
                return new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddRequirements(new PermisoRequirement(clave))
                    .Build();
            }

            return null;
        }
    }
}
