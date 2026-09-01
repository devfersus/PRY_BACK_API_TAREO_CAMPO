using CORE.Infraestructura;
using CORE.Stock_.Web.Dominio.Entidad;
using CORE.Stock_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace CORE.Stock_.Web.Infraestructura.Adaptador
{
    public class StockRepositorioEfCore(CoreDBContext ctx) : IStockRepository
    {
        public async Task<Stock?> ObtenerPorProductoAlmacenAsync(
            string codigoProducto, string? codigoAlmacen, CancellationToken ct = default) =>
            await ctx.Stocks
                     .FirstOrDefaultAsync(
                         s => s.CodigoProducto == codigoProducto &&
                              s.CodigoAlmacen  == codigoAlmacen,
                         ct);

        public async Task<List<Stock>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Stocks.ToListAsync(ct);

        public async Task<List<Stock>> ListarAlertasAsync(CancellationToken ct = default) =>
            await ctx.Stocks
                     .Where(s => s.StockMinimo > 0 && s.StockActual < s.StockMinimo)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Stock stock, CancellationToken ct = default)
        {
            await ctx.Stocks.AddAsync(stock, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Stock stock, CancellationToken ct = default)
        {
            ctx.Stocks.Update(stock);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
