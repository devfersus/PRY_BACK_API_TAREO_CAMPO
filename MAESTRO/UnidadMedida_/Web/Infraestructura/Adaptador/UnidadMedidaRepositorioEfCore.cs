using MAESTRO.Infraestructura;
using MAESTRO.UnidadMedida_.Web.Dominio.Entidad;
using MAESTRO.UnidadMedida_.Web.Dominio.Exceptions;
using MAESTRO.UnidadMedida_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace MAESTRO.UnidadMedida_.Web.Infraestructura.Adaptador
{
    public class UnidadMedidaRepositorioEfCore(MaestroDBContext ctx) : IUnidadMedidaRepository
    {
        public async Task<UnidadMedida> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default) =>
            await ctx.UnidadesMedida
                     .FirstOrDefaultAsync(u => u.Codigo == codigo, ct)
            ?? throw new UnidadMedidaNoEncontradaException(codigo);

        public async Task<List<UnidadMedida>> ListarAsync(CancellationToken ct = default) =>
            await ctx.UnidadesMedida.ToListAsync(ct);

        public async Task<List<UnidadMedida>> ListarActivosAsync(CancellationToken ct = default) =>
            await ctx.UnidadesMedida
                     .Where(u => u.Estado)
                     .ToListAsync(ct);

        public async Task AgregarAsync(UnidadMedida unidadMedida, CancellationToken ct = default)
        {
            await ctx.UnidadesMedida.AddAsync(unidadMedida, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(UnidadMedida unidadMedida, CancellationToken ct = default)
        {
            ctx.UnidadesMedida.Update(unidadMedida);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
