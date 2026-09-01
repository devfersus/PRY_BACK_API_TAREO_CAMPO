using CORE.Stock_.Web.Aplicacion.DTOs;

namespace CORE.Stock_.Web.Aplicacion.Ports
{
    public interface IStockCasoUso
    {
        Task<List<StockDTO>> ListarAsync(CancellationToken ct = default);
        Task<StockDTO?>      ObtenerPorProductoAlmacenAsync(string codigoProducto, string? codigoAlmacen, CancellationToken ct = default);
        Task<List<StockDTO>> ListarAlertasAsync(CancellationToken ct = default);
        Task                 IncrementarAsync(string codigoProducto, string? codigoAlmacen, decimal cantidad, CancellationToken ct = default);
        Task                 DecrementarAsync(string codigoProducto, string? codigoAlmacen, decimal cantidad, CancellationToken ct = default);
        Task                 ConfigurarLimitesAsync(string codigoProducto, string? codigoAlmacen, ConfigurarStockDTO request, CancellationToken ct = default);
    }
}
