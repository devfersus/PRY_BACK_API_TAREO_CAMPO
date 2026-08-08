using SEGURIDAD.Permiso_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Permiso_.Web.Aplicacion.Ports
{
    public interface IPermisoDetalleCasoUso
    {
        Task<List<PermisoDetalleDTO>> ListarPorPermisoAsync(Guid permisoId, CancellationToken ct = default);
        Task                          RegistrarAsync(RegistrarPermisoDetallesDTO request, CancellationToken ct = default);
        Task                          ActualizarAsync(List<ActualizarPermisoDetalleDTO> request, CancellationToken ct = default);
        Task                          EliminarAsync(Guid id, CancellationToken ct = default);
    }
}
