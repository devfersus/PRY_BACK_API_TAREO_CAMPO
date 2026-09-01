using CORE.Ajuste_.Web.Aplicacion.DTOs;
using CORE.Ajuste_.Web.Aplicacion.Ports;
using CORE.Ajuste_.Web.Dominio.Entidad;
using CORE.Ajuste_.Web.Dominio.Interface;
using CORE.Kardex_.Web.Aplicacion.Ports;
using CORE.Stock_.Web.Aplicacion.Ports;

namespace CORE.Ajuste_.Web.Aplicacion.CasosUso
{
    public class AjusteServicioAplicacion(
        IAjusteRepository ajusteRepository,
        IStockCasoUso     stockCasoUso,
        IKardexCasoUso    kardexCasoUso) : IAjusteCasoUso
    {
        public async Task<AjusteDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var ajuste = await ajusteRepository.ObtenerPorIdAsync(id, ct);
            return ToDTO(ajuste);
        }

        public async Task<List<AjusteListadoDTO>> ListarAsync(CancellationToken ct = default) =>
            await ajusteRepository.ListarAsync(ct);

        public async Task RegistrarAsync(RegistrarAjusteDTO request, CancellationToken ct = default)
        {
            var ajuste = Ajuste.Registrar(
                request.CodigoAjuste,
                request.Motivo,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await ajusteRepository.AgregarAsync(ajuste, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarAjusteDTO request, CancellationToken ct = default)
        {
            var ajuste = await ajusteRepository.ObtenerPorIdAsync(id, ct);

            ajuste.Actualizar(
                request.Motivo,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await ajusteRepository.ActualizarAsync(ajuste, ct);
        }

        public async Task RegistrarDetallesMasivoAsync(RegistrarAjusteMasivoDTO request, CancellationToken ct = default)
        {
            var detalles = request.Items.Select(item =>
            {
                var diferencia = (item.CantidadFisica ?? 0) - (item.CantidadSistema ?? 0);
                return AjusteDetalle.Registrar(
                    request.CodigoAjuste,
                    item.CodigoAlmacen,
                    item.CodigoProducto,
                    item.CantidadSistema,
                    item.CantidadFisica,
                    diferencia,
                    item.Comentario,
                    item.Estado,
                    request.UsuarioRegistro,
                    request.Ipv4Registro,
                    request.Ipv6Registro);
            }).ToList();

            await ajusteRepository.AgregarDetallesMasivoAsync(detalles, ct);

            // Corregir stock y registrar en kardex por cada ítem con diferencia
            foreach (var item in request.Items.Where(i => !string.IsNullOrEmpty(i.CodigoProducto)))
            {
                var diferencia = (item.CantidadFisica ?? 0) - (item.CantidadSistema ?? 0);

                if (diferencia > 0)
                    await stockCasoUso.IncrementarAsync(item.CodigoProducto!, item.CodigoAlmacen, diferencia, ct);
                else if (diferencia < 0)
                    await stockCasoUso.DecrementarAsync(item.CodigoProducto!, item.CodigoAlmacen, Math.Abs(diferencia), ct);

                if (diferencia != 0)
                {
                    var stock = await stockCasoUso.ObtenerPorProductoAlmacenAsync(
                        item.CodigoProducto!, item.CodigoAlmacen, ct);

                    await kardexCasoUso.RegistrarMovimientoAsync(
                        tipoMovimiento:  "AJUSTE",
                        codigoProducto:  item.CodigoProducto!,
                        codigoAlmacen:   item.CodigoAlmacen,
                        cantidad:        Math.Abs(diferencia),
                        saldoUnidades:   stock?.StockActual ?? 0,
                        referenciaTipo:  "AJUSTE",
                        referenciaCodig: request.CodigoAjuste,
                        usuarioRegistro: request.UsuarioRegistro,
                        ct);
                }
            }
        }

        public async Task<List<AjusteDetalleListadoDTO>> ListarDetallesAsync(string? codigoAjuste, CancellationToken ct = default) =>
            await ajusteRepository.ListarDetallesAsync(codigoAjuste, ct);

        private static AjusteDTO ToDTO(Ajuste a) =>
            new(a.IdAjuste, a.CodigoAjuste, a.Motivo, a.Estado);
    }
}
