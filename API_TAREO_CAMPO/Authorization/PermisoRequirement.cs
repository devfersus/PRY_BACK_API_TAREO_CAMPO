using Microsoft.AspNetCore.Authorization;

namespace API_TAREO_CAMPO.Authorization
{
    public class PermisoRequirement(string clave) : IAuthorizationRequirement
    {
        public string Clave { get; } = clave;
    }
}
