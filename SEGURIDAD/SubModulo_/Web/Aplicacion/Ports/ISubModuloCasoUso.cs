using SEGURIDAD.SubModulo_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.SubModulo_.Web.Aplicacion.Ports
{
    public interface ISubModuloCasoUso
    {
        Task<SubModuloDTO>       ObtenerPorIdAsync(Guid id,                              CancellationToken ct = default);
        Task<List<SubModuloDTO>> ListarAsync(                                             CancellationToken ct = default);
        Task                     RegistrarAsync(RegistrarSubModuloDTO request,            CancellationToken ct = default);
        Task                     ActualizarAsync(Guid id, ActualizarSubModuloDTO request, CancellationToken ct = default);
        Task                     EliminarAsync(Guid id,                                  CancellationToken ct = default);
    }
}
