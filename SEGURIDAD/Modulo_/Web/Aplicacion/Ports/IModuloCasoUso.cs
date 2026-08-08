using SEGURIDAD.Modulo_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Modulo_.Web.Aplicacion.Ports
{
    public interface IModuloCasoUso
    {
        Task<ModuloDTO>       ObtenerPorIdAsync(Guid id,                            CancellationToken ct = default);
        Task<List<ModuloDTO>> ListarAsync(                                           CancellationToken ct = default);
        Task                  RegistrarAsync(RegistrarModuloDTO request,             CancellationToken ct = default);
        Task                  ActualizarAsync(Guid id, ActualizarModuloDTO request,  CancellationToken ct = default);
        Task                  EliminarAsync(Guid id,                                CancellationToken ct = default);
    }
}
