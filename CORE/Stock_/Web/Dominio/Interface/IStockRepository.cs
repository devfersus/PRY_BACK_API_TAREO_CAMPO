using CORE.Stock_.Web.Dominio.Entidad;

namespace CORE.Stock_.Web.Dominio.Interface
{
    public interface IStockRepository
    {
        Task<Stock?>       ObtenerPorProductoAlmacenAsync(string codigoProducto, string? codigoAlmacen, CancellationToken ct = default);
        Task<List<Stock>>  ListarAsync(CancellationToken ct = default);
        Task<List<Stock>>  ListarAlertasAsync(CancellationToken ct = default);
        Task               AgregarAsync(Stock stock, CancellationToken ct = default);
        Task               ActualizarAsync(Stock stock, CancellationToken ct = default);
    }
}
