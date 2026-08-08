namespace SEGURIDAD.Permiso_.Web.Aplicacion.DTOs
{
    public record PermisoDetalleDTO(
        Guid   Id,
        Guid   PermisoId,
        Guid   ModuloId,    string ModuloDescripcion,
        Guid   SubModuloId, string SubModuloDescripcion,
        Guid   AccionId,    string AccionDescripcion,
        bool   Activo
    );
}
