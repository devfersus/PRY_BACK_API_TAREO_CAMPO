namespace SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.DTOs
{
    public record UsuarioPermisoDTO(Guid Id, Guid UsuarioId, Guid PermisoId, bool Activo);
}
