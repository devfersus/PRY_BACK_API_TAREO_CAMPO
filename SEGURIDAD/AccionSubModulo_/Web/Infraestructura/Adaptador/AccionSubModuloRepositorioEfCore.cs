using SEGURIDAD.AccionSubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Exceptions;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Interface;
using SEGURIDAD.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace SEGURIDAD.AccionSubModulo_.Web.Infraestructura.Adaptador
{
    public class AccionSubModuloRepositorioEfCore(SeguridadDBContext ctx) : IAccionSubModuloRepository
    {
        public async Task<AccionSubModulo> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.AccionSubModulos.FindAsync([id], ct)
            ?? throw new AccionSubModuloNoEncontradaException(id);

        public async Task<List<AccionSubModulo>> ListarAsync(CancellationToken ct = default) =>
            await ctx.AccionSubModulos.ToListAsync(ct);

        public async Task AgregarAsync(AccionSubModulo asm, CancellationToken ct = default)
        {
            await ctx.AccionSubModulos.AddAsync(asm, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(AccionSubModulo asm, CancellationToken ct = default)
        {
            ctx.AccionSubModulos.Update(asm);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(AccionSubModulo asm, CancellationToken ct = default)
        {
            ctx.AccionSubModulos.Update(asm);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
