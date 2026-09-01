using CORE.Infraestructura;
using CORE.Salida_.Web.Aplicacion.DTOs;
using CORE.Salida_.Web.Dominio.Entidad;
using CORE.Salida_.Web.Dominio.Exceptions;
using CORE.Salida_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;

namespace CORE.Salida_.Web.Infraestructura.Adaptador
{
    public class SalidaRepositorioEfCore(CoreDBContext ctx) : ISalidaRepository
    {
        public async Task<Salida> ObtenerPorIdAsync(Guid id, CancellationToken ct = default) =>
            await ctx.Salidas
                     .FirstOrDefaultAsync(s => s.IdSalida == id, ct)
            ?? throw new SalidaNoEncontradaException(id);

        public async Task<List<SalidaListadoDTO>> ListarAsync(CancellationToken ct = default) =>
            await ctx.Database
                     .SqlQueryRaw<SalidaListadoDTO>("""
                         SELECT
                             salida_id     AS "IdSalida",
                             codigo_salida AS "CodigoSalida",
                             motivo        AS "Motivo",
                             estado        AS "Estado"
                         FROM sp_listar_salidas()
                         """)
                     .ToListAsync(ct);

        public async Task AgregarAsync(Salida salida, CancellationToken ct = default)
        {
            await ctx.Salidas.AddAsync(salida, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarAsync(Salida salida, CancellationToken ct = default)
        {
            ctx.Salidas.Update(salida);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task AgregarDetallesMasivoAsync(List<SalidaDetalle> detalles, CancellationToken ct = default)
        {
            await ctx.SalidaDetalles.AddRangeAsync(detalles, ct);
            await ctx.SaveChangesAsync(ct);
        }

        public async Task<List<SalidaDetalleListadoDTO>> ListarDetallesAsync(string? codigoSalida, CancellationToken ct = default) =>
            await ctx.Database
                     .SqlQueryRaw<SalidaDetalleListadoDTO>("""
                         SELECT
                             salida_detalle_id    AS "IdSalidaDetalle",
                             codigo_salida        AS "CodigoSalida",
                             codigo_producto      AS "CodigoProducto",
                             descripcion_producto AS "DescripcionProducto",
                             unidad               AS "Unidad",
                             cantidad             AS "Cantidad",
                             comentario           AS "Comentario",
                             estado               AS "Estado"
                         FROM sp_listar_salida_detalles({0})
                         """, (object?)codigoSalida ?? DBNull.Value)
                     .ToListAsync(ct);
    }
}
