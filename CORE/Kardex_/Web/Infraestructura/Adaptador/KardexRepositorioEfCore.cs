using CORE.Infraestructura;
using CORE.Kardex_.Web.Dominio.Entidad;
using CORE.Kardex_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace CORE.Kardex_.Web.Infraestructura.Adaptador
{
    public class KardexRepositorioEfCore(CoreDBContext ctx) : IKardexRepository
    {
        public async Task<List<Kardex>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Kardexs
                     .OrderByDescending(k => k.FechaMovimiento)
                     .ToListAsync(ct);

        public async Task<List<Kardex>> ListarPorProductoAlmacenAsync(
            string codigoProducto, string? codigoAlmacen, CancellationToken ct = default) =>
            await ctx.Kardexs
                     .Where(k => k.CodigoProducto == codigoProducto &&
                                 k.CodigoAlmacen  == codigoAlmacen)
                     .OrderByDescending(k => k.FechaMovimiento)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Kardex kardex, CancellationToken ct = default)
        {
            await ctx.Kardexs.AddAsync(kardex, ct);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
