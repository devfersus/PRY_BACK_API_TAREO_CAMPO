using CORE.Ajuste_.Web.Aplicacion.DTOs;

namespace CORE.Ajuste_.Web.Aplicacion.Ports
{
    public interface IAjusteCasoUso
    {
        Task<AjusteDTO>                     ObtenerPorIdAsync(Guid id,                              CancellationToken ct = default);
        Task<List<AjusteListadoDTO>>        ListarAsync(                                             CancellationToken ct = default);
        Task                                RegistrarAsync(RegistrarAjusteDTO request,               CancellationToken ct = default);
        Task                                ActualizarAsync(Guid id, ActualizarAjusteDTO request,    CancellationToken ct = default);
        Task                                RegistrarDetallesMasivoAsync(RegistrarAjusteMasivoDTO request, CancellationToken ct = default);
        Task<List<AjusteDetalleListadoDTO>> ListarDetallesAsync(string? codigoAjuste,                CancellationToken ct = default);
    }
}
