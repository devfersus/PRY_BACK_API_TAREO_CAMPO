using SEGURIDAD.SubModulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.SubModulo_.Web.Aplicacion.Ports;
using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Dominio.Interface;

namespace SEGURIDAD.SubModulo_.Web.Aplicacion.CasosUso
{
    public class SubModuloServicioAplicacion(ISubModuloRepository subModuloRepository) : ISubModuloCasoUso
    {
        public async Task<SubModuloDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var s = await subModuloRepository.ObtenerPorIdAsync(id, ct);
            return new SubModuloDTO(s.Id, s.Descripcion, s.Activo);
        }

        public async Task<List<SubModuloDTO>> ListarAsync(CancellationToken ct = default)
        {
            var lista = await subModuloRepository.ListarAsync(ct);
            return lista.Select(s => new SubModuloDTO(s.Id, s.Descripcion, s.Activo)).ToList();
        }

        public async Task RegistrarAsync(RegistrarSubModuloDTO request, CancellationToken ct = default)
        {
            var subModulo = SubModulo.Registrar(request.Descripcion);
            await subModuloRepository.AgregarAsync(subModulo, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarSubModuloDTO request, CancellationToken ct = default)
        {
            var subModulo = await subModuloRepository.ObtenerPorIdAsync(id, ct);
            subModulo.Actualizar(request.Descripcion);
            await subModuloRepository.ActualizarAsync(subModulo, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var subModulo = await subModuloRepository.ObtenerPorIdAsync(id, ct);
            subModulo.EliminarLogico();
            await subModuloRepository.EliminarAsync(subModulo, ct);
        }
    }
}
