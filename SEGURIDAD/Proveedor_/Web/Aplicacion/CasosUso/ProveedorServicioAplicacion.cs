using SEGURIDAD.Proveedor_.Web.Aplicacion.DTOs;
using SEGURIDAD.Proveedor_.Web.Aplicacion.Ports;
using SEGURIDAD.Proveedor_.Web.Dominio.Entidad;
using SEGURIDAD.Proveedor_.Web.Dominio.Interface;

namespace SEGURIDAD.Proveedor_.Web.Aplicacion.CasosUso
{
    public class ProveedorServicioAplicacion(IProveedorRepository proveedorRepository) : IProveedorCasoUso
    {
        public async Task<ProveedorDTO> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default)
        {
            var proveedor = await proveedorRepository.ObtenerPorCodigoAsync(codigo, ct);
            return ToDTO(proveedor);
        }

        public async Task<List<ProveedorDTO>> ListarAsync(CancellationToken ct = default)
        {
            var proveedores = await proveedorRepository.ListarAsync(ct);
            return proveedores.Select(ToDTO).ToList();
        }

        public async Task<List<ProveedorComboDTO>> ListarComboAsync(CancellationToken ct = default)
        {
            var proveedores = await proveedorRepository.ListarActivosAsync(ct);
            return proveedores.Select(p => new ProveedorComboDTO(p.Codigo, p.Descripcion)).ToList();
        }

        public async Task RegistrarAsync(RegistrarProveedorDTO request, CancellationToken ct = default)
        {
            var proveedor = Proveedor.Registrar(
                request.Codigo,
                request.Descripcion,
                request.Comentario,
                request.CodigoUsuario,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await proveedorRepository.AgregarAsync(proveedor, ct);
        }

        public async Task ActualizarAsync(string codigo, ActualizarProveedorDTO request, CancellationToken ct = default)
        {
            var proveedor = await proveedorRepository.ObtenerPorCodigoAsync(codigo, ct);

            proveedor.Actualizar(
                request.Descripcion,
                request.Comentario,
                request.CodigoUsuario,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);  

            await proveedorRepository.ActualizarAsync(proveedor, ct);
        }

        private static ProveedorDTO ToDTO(Proveedor p) =>
            new(p.IdProveedor, p.Codigo, p.Descripcion, p.Comentario, p.CodigoUsuario, p.Estado);
    }
}
