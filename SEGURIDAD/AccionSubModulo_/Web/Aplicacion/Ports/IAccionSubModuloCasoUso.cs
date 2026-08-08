using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.AccionSubModulo_.Web.Aplicacion.Ports
{
    public interface IAccionSubModuloCasoUso
    {
        Task<AccionSubModuloDTO>       ObtenerPorIdAsync(Guid id,                                    CancellationToken ct = default);
        Task<List<AccionSubModuloDTO>> ListarAsync(                                                   CancellationToken ct = default);
        Task                           RegistrarAsync(RegistrarAccionSubModuloDTO request,            CancellationToken ct = default);
        Task                           ActualizarAsync(Guid id, ActualizarAccionSubModuloDTO request, CancellationToken ct = default);
        Task                           EliminarAsync(Guid id,                                        CancellationToken ct = default);
    }
}
