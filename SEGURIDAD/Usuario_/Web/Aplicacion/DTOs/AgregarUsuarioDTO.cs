namespace SEGURIDAD.Usuario_.Web.Aplicacion.DTOs
{
    public record AgregarUsuarioDTO
    {
        public string? Codigo { get; init; }
        public string Nombre { get; init; } = string.Empty;
        public string ApellidoPaterno { get; init; } = string.Empty;
        public string ApellidoMaterno { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Contraseña { get; init; } = string.Empty;
    }
}
