using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using SEGURIDAD.Modulo_.Web.Dominio.Exceptions;
using SEGURIDAD.Modulo_.Web.Dominio.Interface;
using SEGURIDAD.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace SEGURIDAD.Modulo_.Web.Infraestructura.Adaptador
{
    public class ModuloRepositorioEfCore(SeguridadDBContext ctx) : IModuloRepository
    {
        public async Task<Modulo> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Modulos.FindAsync([id], ct)
            ?? throw new ModuloNoEncontradoException(id);

        public async Task<List<Modulo>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Modulos.ToListAsync(ct);

        public async Task AgregarAsync(Modulo modulo, CancellationToken ct = default)
        {
            await ctx.Modulos.AddAsync(modulo, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Modulo modulo, CancellationToken ct = default)
        {
            ctx.Modulos.Update(modulo);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(Modulo modulo, CancellationToken ct = default)
        {
            ctx.Modulos.Update(modulo);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
