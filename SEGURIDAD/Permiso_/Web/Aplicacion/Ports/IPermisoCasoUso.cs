using SEGURIDAD.Permiso_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Permiso_.Web.Aplicacion.Ports
{
    public interface IPermisoCasoUso
    {
        Task<PermisoDTO>       ObtenerPorIdAsync(Guid id,                                  CancellationToken ct = default);
        Task<List<PermisoDTO>> ListarAsync(                                                 CancellationToken ct = default);
        Task                   RegistrarAsync(RegistrarPermisoDTO request,                 CancellationToken ct = default);
        Task                   ActualizarAsync(Guid id, ActualizarPermisoDTO request,      CancellationToken ct = default);
        Task                   EliminarAsync(Guid id,                                      CancellationToken ct = default);
    }
}
