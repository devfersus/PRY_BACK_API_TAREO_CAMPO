using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Dominio.Exceptions;
using SEGURIDAD.SubModulo_.Web.Dominio.Interface;
using SEGURIDAD.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace SEGURIDAD.SubModulo_.Web.Infraestructura.Adaptador
{
    public class SubModuloRepositorioEfCore(SeguridadDBContext ctx) : ISubModuloRepository
    {
        public async Task<SubModulo> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.SubModulos.FindAsync([id], ct)
            ?? throw new SubModuloNoEncontradoException(id);

        public async Task<List<SubModulo>> ListarAsync(CancellationToken ct = default) =>
            await ctx.SubModulos.ToListAsync(ct);

        public async Task AgregarAsync(SubModulo subModulo, CancellationToken ct = default)
        {
            await ctx.SubModulos.AddAsync(subModulo, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(SubModulo subModulo, CancellationToken ct = default)
        {
            ctx.SubModulos.Update(subModulo);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(SubModulo subModulo, CancellationToken ct = default)
        {
            ctx.SubModulos.Update(subModulo);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
