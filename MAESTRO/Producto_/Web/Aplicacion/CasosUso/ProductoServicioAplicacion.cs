using MAESTRO.Producto_.Web.Aplicacion.DTOs;
using MAESTRO.Producto_.Web.Aplicacion.Ports;
using MAESTRO.Producto_.Web.Dominio.Entidad;
using MAESTRO.Producto_.Web.Dominio.Interface;

namespace MAESTRO.Producto_.Web.Aplicacion.CasosUso
{
    public class ProductoServicioAplicacion(IProductoRepository productoRepository) : IProductoCasoUso
    {
        public async Task<ProductoDTO> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default)
        {
            var producto = await productoRepository.ObtenerPorCodigoAsync(codigo, ct);
            return ToDTO(producto);
        }

        public async Task<List<ProductoDTO>> ListarAsync(CancellationToken ct = default)
        {
            var productos = await productoRepository.ListarAsync(ct);
            return productos.Select(ToDTO).ToList();
        }

        public async Task<List<ProductoComboDTO>> ListarComboAsync(CancellationToken ct = default)
        {
            var productos = await productoRepository.ListarActivosAsync(ct);
            return productos.Select(p => new ProductoComboDTO(p.Codigo, p.Descripcion)).ToList();
        }

        public async Task RegistrarAsync(RegistrarProductoDTO request, CancellationToken ct = default)
        {
            var producto = Producto.Registrar(
                request.Codigo,
                request.IdCategoria,
                request.IdProveedor,
                request.Precio,
                request.Descripcion,
                request.Comentario,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await productoRepository.AgregarAsync(producto, ct);
        }

        public async Task ActualizarAsync(string codigo, ActualizarProductoDTO request, CancellationToken ct = default)
        {
            var producto = await productoRepository.ObtenerPorCodigoAsync(codigo, ct);

            producto.Actualizar(
                request.IdCategoria,
                request.IdProveedor,
                request.Precio,
                request.Descripcion,
                request.Comentario,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await productoRepository.ActualizarAsync(producto, ct);
        }

        private static ProductoDTO ToDTO(Producto p) =>
            new(p.IdProducto, p.Codigo, p.IdCategoria, p.IdProveedor, p.Precio,
                p.Descripcion, p.Comentario, p.Estado);
    }
}
