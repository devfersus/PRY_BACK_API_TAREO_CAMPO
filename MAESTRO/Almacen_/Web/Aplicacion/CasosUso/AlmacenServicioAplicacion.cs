using MAESTRO.Almacen_.Web.Aplicacion.DTOs;
using MAESTRO.Almacen_.Web.Aplicacion.Ports;
using MAESTRO.Almacen_.Web.Dominio.Entidad;
using MAESTRO.Almacen_.Web.Dominio.Interface;

namespace MAESTRO.Almacen_.Web.Aplicacion.CasosUso
{
    public class AlmacenServicioAplicacion(IAlmacenRepository almacenRepository)
        : IAlmacenCasoUso
    {
        public async Task<AlmacenDTO> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default)
        {
            var almacen = await almacenRepository.ObtenerPorCodigoAsync(codigo, ct);
            return ToDTO(almacen);
        }

        public async Task<List<AlmacenDTO>> ListarAsync(CancellationToken ct = default)
        {
            var almacenes = await almacenRepository.ListarAsync(ct);
            return almacenes.Select(ToDTO).ToList();
        }

        public async Task<List<AlmacenComboDTO>> ListarComboAsync(CancellationToken ct = default)
        {
            var almacenes = await almacenRepository.ListarActivosAsync(ct);
            return almacenes.Select(a => new AlmacenComboDTO(a.Codigo, a.Descripcion)).ToList();
        }

        public async Task RegistrarAsync(RegistrarAlmacenDTO request, CancellationToken ct = default)
        {
            var almacen = Almacen.Registrar(
                request.Codigo,
                request.Descripcion,
                request.Ubicacion,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await almacenRepository.AgregarAsync(almacen, ct);
        }

        public async Task ActualizarAsync(string codigo, ActualizarAlmacenDTO request, CancellationToken ct = default)
        {
            var almacen = await almacenRepository.ObtenerPorCodigoAsync(codigo, ct);

            almacen.Actualizar(
                request.Descripcion,
                request.Ubicacion,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await almacenRepository.ActualizarAsync(almacen, ct);
        }

        private static AlmacenDTO ToDTO(Almacen a) =>
            new(a.IdAlmacen, a.Codigo, a.Descripcion, a.Ubicacion, a.Estado);
    }
}
