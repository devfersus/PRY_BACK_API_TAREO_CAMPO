namespace SEGURIDAD.Usuario_.Web.Aplicacion.DTOs
{
    public record ActualizarUsuarioDTO(
        string Nombre,
        string ApellidoPaterno,
        string ApellidoMaterno,
        string Email,
        string Contraseña,
        bool Activo
    );
}
