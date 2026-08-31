using MAESTRO.Categoria_.Web.Dominio.Entidad;
using MAESTRO.Categoria_.Web.Dominio.Exceptions;
using MAESTRO.Categoria_.Web.Dominio.Interface;
using MAESTRO.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.Categoria_.Web.Infraestructura.Adaptador
{
    public class CategoriaRepositorioEfCore(MaestroDBContext ctx) : ICategoriaRepository
    {
        public async Task<Categoria> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default) =>
            await ctx.Categorias
                     .FirstOrDefaultAsync(c => c.Codigo == codigo, ct)
            ?? throw new CategoriaNoEncontradaException(codigo);

        public async Task<List<Categoria>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Categorias.ToListAsync(ct);

        public async Task<List<Categoria>> ListarActivosAsync(CancellationToken ct = default) =>
            await ctx.Categorias
                     .Where(c => c.Estado)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Categoria categoria, CancellationToken ct = default)
        {
            await ctx.Categorias.AddAsync(categoria, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Categoria categoria, CancellationToken ct = default)
        {
            ctx.Categorias.Update(categoria);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
