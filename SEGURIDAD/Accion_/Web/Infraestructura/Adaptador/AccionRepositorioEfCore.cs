using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using SEGURIDAD.Accion_.Web.Dominio.Exceptions;
using SEGURIDAD.Accion_.Web.Dominio.Interface;
using SEGURIDAD.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace SEGURIDAD.Accion_.Web.Infraestructura.Adaptador
{
    public class AccionRepositorioEfCore(SeguridadDBContext ctx) : IAccionRepository
    {
        public async Task<Accion> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Acciones.FindAsync([id], ct)
            ?? throw new AccionNoEncontradaException(id);

        public async Task<List<Accion>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Acciones.ToListAsync(ct);

        public async Task AgregarAsync(Accion accion, CancellationToken ct = default)
        {
            await ctx.Acciones.AddAsync(accion, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Accion accion, CancellationToken ct = default)
        {
            ctx.Acciones.Update(accion);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(Accion accion, CancellationToken ct = default)
        {
            ctx.Acciones.Update(accion);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
