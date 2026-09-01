using MAESTRO.UnidadMedida_.Web.Aplicacion.DTOs;
using MAESTRO.UnidadMedida_.Web.Aplicacion.Ports;
using MAESTRO.UnidadMedida_.Web.Dominio.Entidad;
using MAESTRO.UnidadMedida_.Web.Dominio.Interface;

namespace MAESTRO.UnidadMedida_.Web.Aplicacion.CasosUso
{
    public class UnidadMedidaServicioAplicacion(IUnidadMedidaRepository unidadMedidaRepository)
        : IUnidadMedidaCasoUso
    {
        public async Task<UnidadMedidaDTO> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default)
        {
            var unidad = await unidadMedidaRepository.ObtenerPorCodigoAsync(codigo, ct);
            return ToDTO(unidad);
        }

        public async Task<List<UnidadMedidaDTO>> ListarAsync(CancellationToken ct = default)
        {
            var unidades = await unidadMedidaRepository.ListarAsync(ct);
            return unidades.Select(ToDTO).ToList();
        }

        public async Task<List<UnidadMedidaComboDTO>> ListarComboAsync(CancellationToken ct = default)
        {
            var unidades = await unidadMedidaRepository.ListarActivosAsync(ct);
            return unidades.Select(u => new UnidadMedidaComboDTO(u.Codigo, u.Descripcion, u.Abreviatura)).ToList();
        }

        public async Task RegistrarAsync(RegistrarUnidadMedidaDTO request, CancellationToken ct = default)
        {
            var unidad = UnidadMedida.Registrar(
                request.Codigo,
                request.Descripcion,
                request.Abreviatura,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await unidadMedidaRepository.AgregarAsync(unidad, ct);
        }

        public async Task ActualizarAsync(string codigo, ActualizarUnidadMedidaDTO request, CancellationToken ct = default)
        {
            var unidad = await unidadMedidaRepository.ObtenerPorCodigoAsync(codigo, ct);

            unidad.Actualizar(
                request.Descripcion,
                request.Abreviatura,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await unidadMedidaRepository.ActualizarAsync(unidad, ct);
        }

        private static UnidadMedidaDTO ToDTO(UnidadMedida u) =>
            new(u.IdUnidadMedida, u.Codigo, u.Descripcion, u.Abreviatura, u.Estado);
    }
}
