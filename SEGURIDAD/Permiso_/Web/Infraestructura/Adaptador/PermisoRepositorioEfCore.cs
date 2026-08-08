using SEGURIDAD.Infraestructura;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.Permiso_.Web.Dominio.Exceptions;
using SEGURIDAD.Permiso_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace SEGURIDAD.Permiso_.Web.Infraestructura.Adaptador
{
    public class PermisoRepositorioEfCore(SeguridadDBContext ctx) : IPermisoRepository
    {
        public async Task<Permiso> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Permisos.FindAsync([id], ct)
            ?? throw new PermisoNoEncontradoException(id);

        public async Task<List<Permiso>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Permisos.ToListAsync(ct);

        public async Task AgregarAsync(Permiso permiso, CancellationToken ct = default)
        {
            await ctx.Permisos.AddAsync(permiso, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Permiso permiso, CancellationToken ct = default)
        {
            ctx.Permisos.Update(permiso);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(Permiso permiso, CancellationToken ct = default)
        {
            ctx.Permisos.Update(permiso);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
