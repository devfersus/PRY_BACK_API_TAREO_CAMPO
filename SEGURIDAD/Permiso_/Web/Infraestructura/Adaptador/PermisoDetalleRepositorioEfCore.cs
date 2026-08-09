using SEGURIDAD.Infraestructura;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.Permiso_.Web.Dominio.Exceptions;
using SEGURIDAD.Permiso_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace SEGURIDAD.Permiso_.Web.Infraestructura.Adaptador
{
    public class PermisoDetalleRepositorioEfCore(SeguridadDBContext ctx) : IPermisoDetalleRepository
    {
        public async Task<List<PermisoDetalle>> ListarPorPermisoAsync(Guid permisoId, CancellationToken ct = default) =>
            await ctx.PermisoDetalles
                .Include(pd => pd.Modulo)
                .Include(pd => pd.SubModulo)
                .Include(pd => pd.Accion)
                .Where(pd => pd.PermisoId == permisoId)
                .ToListAsync(ct);

        public async Task AgregarRangoAsync(List<PermisoDetalle> detalles, CancellationToken ct = default)
        {
            await ctx.PermisoDetalles.AddRangeAsync(detalles, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task<PermisoDetalle> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.PermisoDetalles
                .Include(pd => pd.Modulo)
                .Include(pd => pd.SubModulo)
                .Include(pd => pd.Accion)
                .FirstOrDefaultAsync(pd => pd.Id == id, ct)
            ?? throw new PermisoDetalleNoEncontradoException(id);

        public async Task<PermisoDetalle?> BuscarPorCombinacionAsync(Guid permisoId ,Guid moduloId, Guid subModuloId, Guid accionId, CancellationToken ct = default) =>
            await ctx.PermisoDetalles.FirstOrDefaultAsync(  
                pd =>
                      pd.PermisoId   == permisoId
                   && pd.ModuloId    == moduloId
                   && pd.SubModuloId == subModuloId
                   && pd.AccionId    == accionId, ct
                );

        public async Task<bool> ExisteCombinacionSinAccionAsync(
            Guid permisoId, Guid moduloId, Guid subModuloId, CancellationToken ct = default) =>
            await ctx.PermisoDetalles.AnyAsync(
                pd =>  pd.PermisoId   == permisoId
                    && pd.ModuloId    == moduloId
                    && pd.SubModuloId == subModuloId, ct);

        public async Task ActualizarAsync(PermisoDetalle detalle, CancellationToken ct = default)
        {
            await ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarAsync(PermisoDetalle detalle, CancellationToken ct = default)
        {
            await ctx.SaveChangesAsync(ct);
        }
    }
}
