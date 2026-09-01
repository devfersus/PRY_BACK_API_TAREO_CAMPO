using CORE.Stock_.Web.Aplicacion.DTOs;
using CORE.Stock_.Web.Aplicacion.Ports;
using CORE.Stock_.Web.Dominio.Entidad;
using CORE.Stock_.Web.Dominio.Interface;

namespace CORE.Stock_.Web.Aplicacion.CasosUso
{
    public class StockServicioAplicacion(IStockRepository stockRepository) : IStockCasoUso
    {
        public async Task<List<StockDTO>> ListarAsync(CancellationToken ct = default)
        {
            var stocks = await stockRepository.ListarAsync(ct);
            return stocks.Select(ToDTO).ToList();
        }

        public async Task<StockDTO?> ObtenerPorProductoAlmacenAsync(
            string codigoProducto, string? codigoAlmacen, CancellationToken ct = default)
        {
            var stock = await stockRepository.ObtenerPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);
            return stock is null ? null : ToDTO(stock);
        }

        public async Task<List<StockDTO>> ListarAlertasAsync(CancellationToken ct = default)
        {
            var stocks = await stockRepository.ListarAlertasAsync(ct);
            return stocks.Select(ToDTO).ToList();
        }

        public async Task IncrementarAsync(
            string codigoProducto, string? codigoAlmacen, decimal cantidad, CancellationToken ct = default)
        {
            var stock = await stockRepository.ObtenerPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);

            if (stock is null)
            {
                var nuevo = Stock.Crear(codigoProducto, codigoAlmacen, cantidad);
                await stockRepository.AgregarAsync(nuevo, ct);
            }
            else
            {
                stock.Incrementar(cantidad);
                await stockRepository.ActualizarAsync(stock, ct);
            }
        }

        public async Task DecrementarAsync(
            string codigoProducto, string? codigoAlmacen, decimal cantidad, CancellationToken ct = default)
        {
            var stock = await stockRepository.ObtenerPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);

            if (stock is null)
            {
                var nuevo = Stock.Crear(codigoProducto, codigoAlmacen, -cantidad);
                await stockRepository.AgregarAsync(nuevo, ct);
            }
            else
            {
                stock.Decrementar(cantidad);
                await stockRepository.ActualizarAsync(stock, ct);
            }
        }

        public async Task ConfigurarLimitesAsync(
            string codigoProducto, string? codigoAlmacen, ConfigurarStockDTO request, CancellationToken ct = default)
        {
            var stock = await stockRepository.ObtenerPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);

            if (stock is null)
            {
                var nuevo = Stock.Crear(codigoProducto, codigoAlmacen, 0);
                nuevo.ConfigurarLimites(request.StockMinimo, request.StockMaximo);
                await stockRepository.AgregarAsync(nuevo, ct);
            }
            else
            {
                stock.ConfigurarLimites(request.StockMinimo, request.StockMaximo);
                await stockRepository.ActualizarAsync(stock, ct);
            }
        }

        private static StockDTO ToDTO(Stock s) =>
            new(s.IdStock, s.CodigoProducto, s.CodigoAlmacen,
                s.StockActual, s.StockMinimo, s.StockMaximo, s.FechaActualizacion);
    }
}
