using MAESTRO.Almacen_.Web.Dominio.Entidad;
using MAESTRO.Almacen_.Web.Dominio.Exceptions;
using MAESTRO.Almacen_.Web.Dominio.Interface;
using MAESTRO.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.Almacen_.Web.Infraestructura.Adaptador
{
    public class AlmacenRepositorioEfCore(MaestroDBContext ctx) : IAlmacenRepository
    {
        public async Task<Almacen> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default) =>
            await ctx.Almacenes
                     .FirstOrDefaultAsync(a => a.Codigo == codigo, ct)
            ?? throw new AlmacenNoEncontradoException(codigo);

        public async Task<List<Almacen>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Almacenes.ToListAsync(ct);

        public async Task<List<Almacen>> ListarActivosAsync(CancellationToken ct = default) =>
            await ctx.Almacenes
                     .Where(a => a.Estado)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Almacen almacen, CancellationToken ct = default)
        {
            await ctx.Almacenes.AddAsync(almacen, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Almacen almacen, CancellationToken ct = default)
        {
            ctx.Almacenes.Update(almacen);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
