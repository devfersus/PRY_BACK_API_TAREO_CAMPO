namespace SEGURIDAD.Permiso_.Web.Aplicacion.DTOs
{
    public record ActualizarPermisoDetalleDTO(Guid PermisoId, Guid ModuloId, Guid SubModuloId, Guid AccionId, bool Activo);
}
