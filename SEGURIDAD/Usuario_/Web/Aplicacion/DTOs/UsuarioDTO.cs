namespace SEGURIDAD.Usuario_.Web.Aplicacion.DTOs
{
    public record UsuarioDTO(
        Guid      Id,
        string?   Codigo,
        string    Nombre,
        string    ApellidoPaterno,
        string    ApellidoMaterno,
        string    Email,
        bool      Activo,
        DateTime  FechaCreacion,
        DateTime? FechaModificacion
    );
}
