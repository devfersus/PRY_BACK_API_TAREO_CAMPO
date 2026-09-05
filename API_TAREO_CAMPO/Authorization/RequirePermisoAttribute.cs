using Microsoft.AspNetCore.Authorization;

namespace API_TAREO_CAMPO.Authorization
{
    /// <summary>
    /// Aplica sobre un action method para requerir que el usuario autenticado
    /// tenga el permiso identificado por la combinación Modulo|SubModulo|Accion.
    /// Hereda de AuthorizeAttribute: implica autenticación automáticamente.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class RequirePermisoAttribute(string modulo, string subModulo, string accion)
        : AuthorizeAttribute(policy: $"Permiso:{modulo.ToUpper()}|{subModulo.ToUpper()}|{accion.ToUpper()}")
    {
        public string Clave { get; } = $"{modulo.ToUpper()}|{subModulo.ToUpper()}|{accion.ToUpper()}";
    }
}
