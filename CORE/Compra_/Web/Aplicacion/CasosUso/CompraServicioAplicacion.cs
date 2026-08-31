using CORE.Compra_.Web.Aplicacion.DTOs;
using CORE.Compra_.Web.Aplicacion.Ports;
using CORE.Compra_.Web.Dominio.Entidad;
using CORE.Compra_.Web.Dominio.Interface;

namespace CORE.Compra_.Web.Aplicacion.CasosUso
{
    public class CompraServicioAplicacion(ICompraRepository compraRepository) : ICompraCasoUso
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
                item.Unidad,
                item.Cantidad,
                item.CodigoProducto,
                item.Comentario,
                item.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro)).ToList();

            await compraRepository.AgregarDetallesMasivoAsync(detalles, ct);
        }

        public async Task<List<CompraDetalleListadoDTO>> ListarDetallesAsync(string? codigoCompra, string? codigoProveedor, CancellationToken ct = default) =>
            await compraRepository.ListarDetallesAsync(codigoCompra, codigoProveedor, ct);

        private static CompraDTO ToDTO(Compra c) =>
            new(c.IdCompra, c.CodigoCompra, c.CodigoProveedor, c.Estado);
    }
}
