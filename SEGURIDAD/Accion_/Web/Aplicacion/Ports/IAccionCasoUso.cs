using SEGURIDAD.Accion_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Accion_.Web.Aplicacion.Ports
{
    public interface IAccionCasoUso
    {
        Task<AccionDTO>       ObtenerPorIdAsync(Guid id,                            CancellationToken ct = default);
        Task<List<AccionDTO>> ListarAsync(                                           CancellationToken ct = default);
        Task                  RegistrarAsync(RegistrarAccionDTO request,             CancellationToken ct = default);
        Task                  ActualizarAsync(Guid id, ActualizarAccionDTO request,  CancellationToken ct = default);
        Task                  EliminarAsync(Guid id,                                CancellationToken ct = default);
    }
}
