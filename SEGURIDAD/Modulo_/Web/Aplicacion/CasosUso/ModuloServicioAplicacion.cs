using SEGURIDAD.Modulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.Modulo_.Web.Aplicacion.Ports;
using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using SEGURIDAD.Modulo_.Web.Dominio.Interface;

namespace SEGURIDAD.Modulo_.Web.Aplicacion.CasosUso
{
    public class ModuloServicioAplicacion(IModuloRepository moduloRepository) : IModuloCasoUso
    {
        public async Task<ModuloDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var modulo = await moduloRepository.ObtenerPorIdAsync(id, ct);
            return new ModuloDTO(modulo.Id, modulo.Descripcion, modulo.Activo);
        }

        public async Task<List<ModuloDTO>> ListarAsync(CancellationToken ct = default)
        {
            var modulos = await moduloRepository.ListarAsync(ct);
            return modulos.Select(m => new ModuloDTO(m.Id, m.Descripcion, m.Activo)).ToList();
        }

        public async Task RegistrarAsync(RegistrarModuloDTO request, CancellationToken ct = default)
        {
            var modulo = Modulo.Registrar(request.Descripcion);
            await moduloRepository.AgregarAsync(modulo, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarModuloDTO request, CancellationToken ct = default)
        {
            var modulo = await moduloRepository.ObtenerPorIdAsync(id, ct);
            modulo.Actualizar(request.Descripcion, request.Activo);
            await moduloRepository.ActualizarAsync(modulo, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var modulo = await moduloRepository.ObtenerPorIdAsync(id, ct);
            modulo.EliminarLogico();
            await moduloRepository.EliminarAsync(modulo, ct);
        }
    }
}
