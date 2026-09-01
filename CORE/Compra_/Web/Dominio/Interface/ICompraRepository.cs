using CORE.Compra_.Web.Aplicacion.DTOs;
using CORE.Compra_.Web.Dominio.Entidad;

namespace CORE.Compra_.Web.Dominio.Interface
{
    public interface ICompraRepository
    {
        Task<Compra>                        ObtenerPorIdAsync(Guid id,                                                                        CancellationToken ct = default);
        Task<List<CompraListadoDTO>>         ListarAsync(                                                                                      CancellationToken ct = default);
        Task                                 AgregarAsync(Compra compra,                                                                       CancellationToken ct = default);
        Task                                 ActualizarAsync(Compra compra,                                                                    CancellationToken ct = default);
        Task                                 AgregarDetallesMasivoAsync(List<CompraDetalle> detalles,                                          CancellationToken ct = default);
        Task<List<CompraDetalleListadoDTO>>  ListarDetallesAsync(string? codigoCompra, string? codigoProveedor, CancellationToken ct = default);
    }
}
