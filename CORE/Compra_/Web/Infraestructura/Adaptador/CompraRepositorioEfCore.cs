using CORE.Compra_.Web.Aplicacion.DTOs;
using CORE.Compra_.Web.Dominio.Entidad;
using CORE.Compra_.Web.Dominio.Exceptions;
using CORE.Compra_.Web.Dominio.Interface;
using CORE.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace CORE.Compra_.Web.Infraestructura.Adaptador
{
    public class CompraRepositorioEfCore(CoreDBContext ctx) : ICompraRepository
    {
        public async Task<Compra> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Compras
                     .FirstOrDefaultAsync(c => c.IdCompra == id, ct)
            ?? throw new CompraNoEncontradaException(id);

        public async Task<List<CompraListadoDTO>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Database
                     .SqlQueryRaw<CompraListadoDTO>("""
                         SELECT
                             compra_id             AS "IdCompra",
                             codigo_compra         AS "CodigoCompra",
                             codigo_proveedor      AS "CodigoProveedor",
                             descripcion_proveedor AS "DescripcionProveedor",
                             estado                AS "Estado"
                         FROM sp_listar_compras()
                         """)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Compra compra, CancellationToken ct = default)
        {
            await ctx.Compras.AddAsync(compra, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Compra compra, CancellationToken ct = default)
        {
            ctx.Compras.Update(compra);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task AgregarDetallesMasivoAsync(List<CompraDetalle> detalles, CancellationToken ct = default)
        {
            await ctx.CompraDetalles.AddRangeAsync(detalles, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task<List<CompraDetalleListadoDTO>> ListarDetallesAsync(string? codigoCompra, string? codigoProveedor, CancellationToken ct = default) =>
            await ctx.Database
                     .SqlQueryRaw<CompraDetalleListadoDTO>("""
                         SELECT
                             compra_detalle_id    AS "IdCompraDetalle",
                             codigo_compra        AS "CodigoCompra",
                             codigo_producto      AS "CodigoProducto",
                             descripcion_producto AS "DescripcionProducto",
                             unidad               AS "Unidad",
                             cantidad             AS "Cantidad",
                             comentario           AS "Comentario",
                             estado               AS "Estado"
                         FROM sp_listar_compra_detalles({0}, {1})
                         """, (object?)codigoCompra ?? DBNull.Value, (object?)codigoProveedor ?? DBNull.Value)
                     .ToListAsync(ct);
    }
}
