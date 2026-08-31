using MAESTRO.Infraestructura;
using MAESTRO.Pais_.Web.Dominio.Entidad;
using MAESTRO.Pais_.Web.Dominio.Exceptions;
using MAESTRO.Pais_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.Pais_.Web.Infraestructura.Adaptador
{
    public class PaisRepositorioEfCore(MaestroDBContext ctx) : IPaisRepository
    {
        public async Task<Pais> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Paises.FindAsync([id], ct)
            ?? throw new PaisNoEncontradoException(id);

        public async Task<List<Pais>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Paises.ToListAsync(ct);

        public async Task AgregarAsync(Pais pais, CancellationToken ct = default)
        {
            await ctx.Paises.AddAsync(pais, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Pais pais, CancellationToken ct = default)
        {
            ctx.Paises.Update(pais);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(Pais pais, CancellationToken ct = default)
        {
            ctx.Paises.Update(pais);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
