using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.AccionSubModulo_.Web.Aplicacion.Ports;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Entidad;
using SEGURIDAD.AccionSubModulo_.Web.Dominio.Interface;

namespace SEGURIDAD.AccionSubModulo_.Web.Aplicacion.CasosUso
{
    public class AccionSubModuloServicioAplicacion(IAccionSubModuloRepository accionSubModuloRepository) : IAccionSubModuloCasoUso
    {
        public async Task<AccionSubModuloDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var asm = await accionSubModuloRepository.ObtenerPorIdAsync(id, ct);
            return new AccionSubModuloDTO(asm.Id, asm.SubModuloId, asm.AccionId, asm.Activo);
        }

        public async Task<List<AccionSubModuloDTO>> ListarAsync(CancellationToken ct = default)
        {
            var lista = await accionSubModuloRepository.ListarAsync(ct);
            return lista.Select(a => new AccionSubModuloDTO(a.Id, a.SubModuloId, a.AccionId, a.Activo)).ToList();
        }

        public async Task RegistrarAsync(RegistrarAccionSubModuloDTO request, CancellationToken ct = default)
        {
            var asm = AccionSubModulo.Registrar(request.SubModuloId, request.AccionId);
            await accionSubModuloRepository.AgregarAsync(asm, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarAccionSubModuloDTO request, CancellationToken ct = default)
        {
            var asm = await accionSubModuloRepository.ObtenerPorIdAsync(id, ct);
            asm.Actualizar(request.SubModuloId, request.AccionId);
            await accionSubModuloRepository.ActualizarAsync(asm, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var asm = await accionSubModuloRepository.ObtenerPorIdAsync(id, ct);
            asm.EliminarLogico();
            await accionSubModuloRepository.EliminarAsync(asm, ct);
        }
    }
}
