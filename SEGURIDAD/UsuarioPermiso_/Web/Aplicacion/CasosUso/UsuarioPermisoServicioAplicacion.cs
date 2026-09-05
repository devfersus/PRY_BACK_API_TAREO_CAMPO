using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.DTOs;
using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.Ports;
using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Entidad;
using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Interface;

namespace SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.CasosUso
{
    public class UsuarioPermisoServicioAplicacion(
        IUsuarioPermisoRepository usuarioPermisoRepository
    ) : IUsuarioPermisoCasoUso
    {
        public async Task<List<UsuarioPermisoDTO>> ListarPorUsuarioAsync(Guid usuarioId, CancellationToken ct = default)
        {
            var lista = await usuarioPermisoRepository.ListarPorUsuarioAsync(usuarioId, ct);
            return lista.Select(up => new UsuarioPermisoDTO(up.Id, up.UsuarioId, up.PermisoId, up.Activo)).ToList();
        }

        public async Task AsignarAsync(AsignarUsuarioPermisoDTO request, CancellationToken ct = default)
        {
            var existente = await usuarioPermisoRepository.BuscarAsync(request.UsuarioId, request.PermisoId, ct);
            if (existente is not null)
            {
                existente.Activar();
                await usuarioPermisoRepository.ActualizarAsync(existente, ct);
                return;
            }
            var nuevo = UsuarioPermiso.Asignar(request.UsuarioId, request.PermisoId);
            await usuarioPermisoRepository.AgregarAsync(nuevo, ct);
        }

        public async Task RevocarAsync(Guid usuarioId, Guid permisoId, CancellationToken ct = default)
        {
            var asignacion = await usuarioPermisoRepository.BuscarAsync(usuarioId, permisoId, ct);
            if (asignacion is null) return;
            asignacion.Desactivar();
            await usuarioPermisoRepository.ActualizarAsync(asignacion, ct);
        }
    }
}
