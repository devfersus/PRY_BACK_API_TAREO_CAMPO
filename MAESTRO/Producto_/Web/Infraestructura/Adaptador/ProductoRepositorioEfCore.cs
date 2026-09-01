using MAESTRO.Infraestructura;
using MAESTRO.Producto_.Web.Dominio.Entidad;
using MAESTRO.Producto_.Web.Dominio.Exceptions;
using MAESTRO.Producto_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.Producto_.Web.Infraestructura.Adaptador
{
    public class ProductoRepositorioEfCore(MaestroDBContext ctx) : IProductoRepository
    {
        public async Task<Producto> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default) =>
            await ctx.Productos
                     .FirstOrDefaultAsync(p => p.Codigo == codigo, ct)
            ?? throw new ProductoNoEncontradoException(codigo);

        public async Task<List<Producto>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Productos.ToListAsync(ct);

        public async Task<List<Producto>> ListarActivosAsync(CancellationToken ct = default) =>
            await ctx.Productos
                     .Where(p => p.Estado)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Producto producto, CancellationToken ct = default)
        {
            await ctx.Productos.AddAsync(producto, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Producto producto, CancellationToken ct = default)
        {
            ctx.Productos.Update(producto);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
