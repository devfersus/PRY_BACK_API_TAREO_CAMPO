namespace SEGURIDAD.Permiso_.Web.Aplicacion.DTOs
{
    public record RegistrarPermisoDetallesDTO(
        Guid                      PermisoId,
        List<PermisoDetalleItemDTO> Detalles
    );

    public record PermisoDetalleItemDTO(Guid ModuloId, Guid SubModuloId, Guid AccionId);
}
