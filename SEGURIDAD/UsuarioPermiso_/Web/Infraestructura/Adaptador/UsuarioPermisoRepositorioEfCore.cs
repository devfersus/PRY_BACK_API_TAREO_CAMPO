using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Infraestructura;
using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Entidad;
using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Interface;

namespace SEGURIDAD.UsuarioPermiso_.Web.Infraestructura.Adaptador
{
    public class UsuarioPermisoRepositorioEfCore(SeguridadDBContext ctx) : IUsuarioPermisoRepository
    {
        public Task<List<UsuarioPermiso>> ListarPorUsuarioAsync(Guid usuarioId, CancellationToken ct = default) =>
            ctx.UsuarioPermisos
               .Where(up => up.UsuarioId == usuarioId && up.Activo)
               .ToListAsync(ct);

        public Task<UsuarioPermiso?> BuscarAsync(Guid usuarioId, Guid permisoId, CancellationToken ct = default) =>
            ctx.UsuarioPermisos
               .FirstOrDefaultAsync(up => up.UsuarioId == usuarioId && up.PermisoId == permisoId, ct);

        public async Task AgregarAsync(UsuarioPermiso usuarioPermiso, CancellationToken ct = default)
        {
            await ctx.UsuarioPermisos.AddAsync(usuarioPermiso, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(UsuarioPermiso usuarioPermiso, CancellationToken ct = default)
        {
            ctx.UsuarioPermisos.Update(usuarioPermiso);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
