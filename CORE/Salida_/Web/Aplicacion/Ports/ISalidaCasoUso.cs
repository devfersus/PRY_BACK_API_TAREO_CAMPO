using CORE.Salida_.Web.Aplicacion.DTOs;

namespace CORE.Salida_.Web.Aplicacion.Ports
{
    public interface ISalidaCasoUso
    {
        Task<SalidaDTO>                     ObtenerPorIdAsync(Guid id,                                                        CancellationToken ct = default);
        Task<List<SalidaListadoDTO>>         ListarAsync(                                                                      CancellationToken ct = default);
        Task                                 RegistrarAsync(RegistrarSalidaDTO request,                                        CancellationToken ct = default);
        Task                                 ActualizarAsync(Guid id, ActualizarSalidaDTO request,                             CancellationToken ct = default);
        Task                                 RegistrarDetallesMasivoAsync(RegistrarSalidaMasivoDTO request,                    CancellationToken ct = default);
        Task<List<SalidaDetalleListadoDTO>>  ListarDetallesAsync(string? codigoSalida,                                         CancellationToken ct = default);
    }
}
