using CORE.Compra_.Web.Aplicacion.DTOs;

namespace CORE.Compra_.Web.Aplicacion.Ports
{
    public interface ICompraCasoUso
    {
        Task<CompraDTO>                     ObtenerPorIdAsync(Guid id,                                                                                        CancellationToken ct = default);
        Task<List<CompraListadoDTO>>         ListarAsync(                                                                                                      CancellationToken ct = default);
        Task                                 RegistrarAsync(RegistrarCompraDTO request,                                                                        CancellationToken ct = default);
        Task                                 ActualizarAsync(Guid id, ActualizarCompraDTO request,                                                             CancellationToken ct = default);
        Task                                 RegistrarDetallesMasivoAsync(RegistrarCompraMasivoDTO request,                                                    CancellationToken ct = default);
        Task<List<CompraDetalleListadoDTO>>  ListarDetallesAsync(string? codigoCompra, string? codigoProveedor, CancellationToken ct = default);
    }
}
