using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Infraestructura;
using SEGURIDAD.Proveedor_.Web.Dominio.Entidad;
using SEGURIDAD.Proveedor_.Web.Dominio.Exceptions;
using SEGURIDAD.Proveedor_.Web.Dominio.Interface;

namespace SEGURIDAD.Proveedor_.Web.Infraestructura.Adaptador
{
    public class ProveedorRepositorioEfCore(SeguridadDBContext ctx) : IProveedorRepository
    {
        public async Task<Proveedor> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default) =>
            await ctx.Proveedores
                     .FirstOrDefaultAsync(p => p.Codigo == codigo, ct)
            ?? throw new ProveedorNoEncontradoException(codigo);

        public async Task<List<Proveedor>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Proveedores.ToListAsync(ct);

        public async Task<List<Proveedor>> ListarActivosAsync(CancellationToken ct = default) =>
            await ctx.Proveedores.Where(p => p.Estado).ToListAsync(ct);

        public async Task AgregarAsync(Proveedor proveedor, CancellationToken ct = default)
        {
            await ctx.Proveedores.AddAsync(proveedor, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Proveedor proveedor, CancellationToken ct = default)
        {
            ctx.Proveedores.Update(proveedor);
            await ctx.SaveChangesAsync(ct);
        }
    }
}
