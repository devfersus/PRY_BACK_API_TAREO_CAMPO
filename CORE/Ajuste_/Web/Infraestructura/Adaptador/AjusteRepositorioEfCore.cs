using CORE.Ajuste_.Web.Aplicacion.DTOs;
using CORE.Ajuste_.Web.Dominio.Entidad;
using CORE.Ajuste_.Web.Dominio.Exceptions;
using CORE.Ajuste_.Web.Dominio.Interface;
using CORE.Infraestructura;
using Microsoft.EntityFrameworkCore;

namespace CORE.Ajuste_.Web.Infraestructura.Adaptador
{
    public class AjusteRepositorioEfCore(CoreDBContext ctx) : IAjusteRepository
    {
        public async Task<Ajuste> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Ajustes
                     .FirstOrDefaultAsync(a => a.IdAjuste == id, ct)
            ?? throw new AjusteNoEncontradoException(id);

        public async Task<List<AjusteListadoDTO>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Database
                     .SqlQueryRaw<AjusteListadoDTO>("""
                         SELECT
                             ajuste_id     AS "IdAjuste",
                             codigo_ajuste AS "CodigoAjuste",
                             motivo        AS "Motivo",
                             estado        AS "Estado"
                         FROM sp_listar_ajustes()
                         """)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Ajuste ajuste, CancellationToken ct = default)
        {
            await ctx.Ajustes.AddAsync(ajuste, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Ajuste ajuste, CancellationToken ct = default)
        {
            ctx.Ajustes.Update(ajuste);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task AgregarDetallesMasivoAsync(List<AjusteDetalle> detalles, CancellationToken ct = default)
        {
            await ctx.AjusteDetalles.AddRangeAsync(detalles, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task<List<AjusteDetalleListadoDTO>> ListarDetallesAsync(string? codigoAjuste, CancellationToken ct = default) =>
            await ctx.Database
                     .SqlQueryRaw<AjusteDetalleListadoDTO>("""
                         SELECT
                             ajuste_detalle_id    AS "IdAjusteDetalle",
                             codigo_ajuste        AS "CodigoAjuste",
                             codigo_producto      AS "CodigoProducto",
                             descripcion_producto AS "DescripcionProducto",
                             codigo_almacen       AS "CodigoAlmacen",
                             cantidad_sistema     AS "CantidadSistema",
                             cantidad_fisica      AS "CantidadFisica",
                             diferencia           AS "Diferencia",
                             comentario           AS "Comentario",
                             estado               AS "Estado"
                         FROM sp_listar_ajuste_detalles({0})
                         """, (object?)codigoAjuste ?? DBNull.Value)
                     .ToListAsync(ct);
    }
}
