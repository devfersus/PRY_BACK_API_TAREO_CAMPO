using CORE.Kardex_.Web.Aplicacion.DTOs;
using CORE.Kardex_.Web.Aplicacion.Ports;
using CORE.Kardex_.Web.Dominio.Entidad;
using CORE.Kardex_.Web.Dominio.Interface;

namespace CORE.Kardex_.Web.Aplicacion.CasosUso
{
    public class KardexServicioAplicacion(IKardexRepository kardexRepository) : IKardexCasoUso
    {
        public async Task<List<KardexDTO>> ListarAsync(CancellationToken ct = default)
        {
            var movimientos = await kardexRepository.ListarAsync(ct);
            return movimientos.Select(ToDTO).ToList();
        }

        public async Task<List<KardexDTO>> ListarPorProductoAlmacenAsync(
            string codigoProducto, string? codigoAlmacen, CancellationToken ct = default)
        {
            var movimientos = await kardexRepository.ListarPorProductoAlmacenAsync(codigoProducto, codigoAlmacen, ct);
            return movimientos.Select(ToDTO).ToList();
        }

        public async Task RegistrarMovimientoAsync(
            string  tipoMovimiento,
            string  codigoProducto,
            string? codigoAlmacen,
            decimal cantidad,
            decimal saldoUnidades,
            string? referenciaTipo,
            string? referenciaCodig,
            string? usuarioRegistro,
            CancellationToken ct = default)
        {
            var kardex = Kardex.Registrar(
                tipoMovimiento,
                codigoProducto,
                codigoAlmacen,
                cantidad,
                saldoUnidades,
                referenciaTipo,
                referenciaCodig,
                usuarioRegistro);

            await kardexRepository.AgregarAsync(kardex, ct);
        }

        private static KardexDTO ToDTO(Kardex k) =>
            new(k.IdKardex, k.TipoMovimiento, k.CodigoProducto, k.CodigoAlmacen,
                k.Cantidad, k.SaldoUnidades, k.ReferenciaTipo, k.ReferenciaCodig,
                k.FechaMovimiento, k.UsuarioRegistro);
    }
}
