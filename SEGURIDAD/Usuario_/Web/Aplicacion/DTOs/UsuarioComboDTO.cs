namespace SEGURIDAD.Usuario_.Web.Aplicacion.DTOs
{
    public record UsuarioComboDTO(
        string? Codigo,
        string  Nombre,
        string  ApellidoPaterno,
        string  ApellidoMaterno
    );
}
