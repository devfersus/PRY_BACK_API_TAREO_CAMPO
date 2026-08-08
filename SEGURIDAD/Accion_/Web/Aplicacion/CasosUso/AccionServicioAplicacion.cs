using SEGURIDAD.Accion_.Web.Aplicacion.DTOs;
using SEGURIDAD.Accion_.Web.Aplicacion.Ports;
using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using SEGURIDAD.Accion_.Web.Dominio.Interface;

namespace SEGURIDAD.Accion_.Web.Aplicacion.CasosUso
{
    public class AccionServicioAplicacion(IAccionRepository accionRepository) : IAccionCasoUso
    {
        public async Task<AccionDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var accion = await accionRepository.ObtenerPorIdAsync(id, ct);
            return new AccionDTO(accion.Id, accion.Descripcion, accion.Activo);
        }

        public async Task<List<AccionDTO>> ListarAsync(CancellationToken ct = default)
        {
            var acciones = await accionRepository.ListarAsync(ct);
            return acciones.Select(a => new AccionDTO(a.Id, a.Descripcion, a.Activo)).ToList();
        }

        public async Task RegistrarAsync(RegistrarAccionDTO request, CancellationToken ct = default)
        {
            var accion = Accion.Registrar(request.descripcion);
            await accionRepository.AgregarAsync(accion, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarAccionDTO request, CancellationToken ct = default)
        {
            var accion = await accionRepository.ObtenerPorIdAsync(id, ct);
            accion.Actualizar(request.Descripcion);
            await accionRepository.ActualizarAsync(accion, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var accion = await accionRepository.ObtenerPorIdAsync(id, ct);
            accion.EliminarLogico();
            await accionRepository.EliminarAsync(accion, ct);
        }
    }
}
