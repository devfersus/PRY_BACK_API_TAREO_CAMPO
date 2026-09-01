using CORE.Kardex_.Web.Aplicacion.Ports;
using CORE.Salida_.Web.Aplicacion.DTOs;
using CORE.Salida_.Web.Aplicacion.Ports;
using CORE.Salida_.Web.Dominio.Entidad;
using CORE.Salida_.Web.Dominio.Interface;
using CORE.Stock_.Web.Aplicacion.Ports;

namespace CORE.Salida_.Web.Aplicacion.CasosUso
{
    public class SalidaServicioAplicacion(
        ISalidaRepository salidaRepository,
        IStockCasoUso     stockCasoUso,
        IKardexCasoUso    kardexCasoUso) : ISalidaCasoUso
    {
        public async Task<SalidaDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var salida = await salidaRepository.ObtenerPorIdAsync(id, ct);
            return ToDTO(salida);
        }

        public async Task<List<SalidaListadoDTO>> ListarAsync(CancellationToken ct = default) =>
            await salidaRepository.ListarAsync(ct);

        public async Task RegistrarAsync(RegistrarSalidaDTO request, CancellationToken ct = default)
        {
            var salida = Salida.Registrar(
                request.CodigoSalida,
                request.Motivo,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await salidaRepository.AgregarAsync(salida, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarSalidaDTO request, CancellationToken ct = default)
        {
            var salida = await salidaRepository.ObtenerPorIdAsync(id, ct);

            salida.Actualizar(
                request.Motivo,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await salidaRepository.ActualizarAsync(salida, ct);
        }

        public async Task RegistrarDetallesMasivoAsync(RegistrarSalidaMasivoDTO request, CancellationToken ct = default)
        {
            var detalles = request.Items.Select(item => SalidaDetalle.Registrar(
                request.CodigoSalida,
                item.CodigoAlmacen,
                item.CodigoProducto,
                item.Unidad,
                item.Cantidad,
                item.Comentario,
                item.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro)).ToList();

            await salidaRepository.AgregarDetallesMasivoAsync(detalles, ct);

            // Descontar stock y registrar en kardex por cada ítem
            foreach (var item in request.Items.Where(i => !string.IsNullOrEmpty(i.CodigoProducto)))
            {
                await stockCasoUso.DecrementarAsync(
                    item.CodigoProducto!,
                    item.CodigoAlmacen,
                    item.Cantidad ?? 0,
                    ct);

                var stock = await stockCasoUso.ObtenerPorProductoAlmacenAsync(
                    item.CodigoProducto!, item.CodigoAlmacen, ct);

                await kardexCasoUso.RegistrarMovimientoAsync(
                    tipoMovimiento:  "SALIDA",
                    codigoProducto:  item.CodigoProducto!,
                    codigoAlmacen:   item.CodigoAlmacen,
                    cantidad:        item.Cantidad ?? 0,
                    saldoUnidades:   stock?.StockActual ?? 0,
                    referenciaTipo:  "SALIDA",
                    referenciaCodig: request.CodigoSalida,
                    usuarioRegistro: request.UsuarioRegistro,
                    ct);
            }
        }

        public async Task<List<SalidaDetalleListadoDTO>> ListarDetallesAsync(string? codigoSalida, CancellationToken ct = default) =>
            await salidaRepository.ListarDetallesAsync(codigoSalida, ct);

        private static SalidaDTO ToDTO(Salida s) =>
            new(s.IdSalida, s.CodigoSalida, s.Motivo, s.Estado);
    }
}
