using CORE.Compra_.Web.Aplicacion.DTOs;
using CORE.Compra_.Web.Aplicacion.Ports;
using CORE.Compra_.Web.Dominio.Entidad;
using CORE.Compra_.Web.Dominio.Interface;
using CORE.Kardex_.Web.Aplicacion.Ports;
using CORE.Stock_.Web.Aplicacion.Ports;

namespace CORE.Compra_.Web.Aplicacion.CasosUso
{
    public class CompraServicioAplicacion(
        ICompraRepository compraRepository,
        IStockCasoUso     stockCasoUso,
        IKardexCasoUso    kardexCasoUso) : ICompraCasoUso
    {
        public async Task<CompraDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var compra = await compraRepository.ObtenerPorIdAsync(id, ct);
            return ToDTO(compra);
        }

        public async Task<List<CompraListadoDTO>> ListarAsync(CancellationToken ct = default) =>
            await compraRepository.ListarAsync(ct);

        public async Task RegistrarAsync(RegistrarCompraDTO request, CancellationToken ct = default)
        {
            var compra = Compra.Registrar(
                request.CodigoCompra,
                request.CodigoProveedor,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await compraRepository.AgregarAsync(compra, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarCompraDTO request, CancellationToken ct = default)
        {
            var compra = await compraRepository.ObtenerPorIdAsync(id, ct);

            compra.Actualizar(
                request.CodigoProveedor,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await compraRepository.ActualizarAsync(compra, ct);
        }

        public async Task RegistrarDetallesMasivoAsync(RegistrarCompraMasivoDTO request, CancellationToken ct = default)
        {
            var detalles = request.Items.Select(item => CompraDetalle.Registrar(
                request.CodigoCompra,
                item.CodigoAlmacen,
                item.Unidad,
                item.Cantidad,
                item.CodigoProducto,
                item.Comentario,
                item.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro)).ToList();

            await compraRepository.AgregarDetallesMasivoAsync(detalles, ct);

            // Actualizar stock y registrar en kardex por cada ítem
            foreach (var item in request.Items.Where(i => !string.IsNullOrEmpty(i.CodigoProducto)))
            {
                await stockCasoUso.IncrementarAsync(
                    item.CodigoProducto!,
                    item.CodigoAlmacen,
                    item.Cantidad ?? 0,
                    ct);

                var stock = await stockCasoUso.ObtenerPorProductoAlmacenAsync(
                    item.CodigoProducto!, item.CodigoAlmacen, ct);

                await kardexCasoUso.RegistrarMovimientoAsync(
                    tipoMovimiento:  "ENTRADA",
                    codigoProducto:  item.CodigoProducto!,
                    codigoAlmacen:   item.CodigoAlmacen,
                    cantidad:        item.Cantidad ?? 0,
                    saldoUnidades:   stock?.StockActual ?? 0,
                    referenciaTipo:  "COMPRA",
                    referenciaCodig: request.CodigoCompra,
                    usuarioRegistro: request.UsuarioRegistro,
                    ct);
            }
        }

        public async Task<List<CompraDetalleListadoDTO>> ListarDetallesAsync(string? codigoCompra, string? codigoProveedor, CancellationToken ct = default) =>
            await compraRepository.ListarDetallesAsync(codigoCompra, codigoProveedor, ct);

        private static CompraDTO ToDTO(Compra c) =>
            new(c.IdCompra, c.CodigoCompra, c.CodigoProveedor, c.Estado);
    }
}
