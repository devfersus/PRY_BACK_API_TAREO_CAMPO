using SEGURIDAD.Permiso_.Web.Aplicacion.DTOs;
using SEGURIDAD.Permiso_.Web.Aplicacion.Ports;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.Permiso_.Web.Dominio.Interface;

namespace SEGURIDAD.Permiso_.Web.Aplicacion.CasosUso
{
    public class PermisoServicioAplicacion(IPermisoRepository permisoRepository) : IPermisoCasoUso
    {
        public async Task<PermisoDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var permiso = await permisoRepository.ObtenerPorIdAsync(id, ct);
            return new PermisoDTO(permiso.Id, permiso.Descripcion, permiso.Activo);
        }

        public async Task<List<PermisoDTO>> ListarAsync(CancellationToken ct = default)
        {
            var permisos = await permisoRepository.ListarAsync(ct);
            return permisos.Select(p => new PermisoDTO(p.Id, p.Descripcion, p.Activo)).ToList();
        }

        public async Task RegistrarAsync(RegistrarPermisoDTO request, CancellationToken ct = default)
        {
            var permiso = Permiso.Registrar(request.Descripcion);
            await permisoRepository.AgregarAsync(permiso, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarPermisoDTO request, CancellationToken ct = default)
        {
            var permiso = await permisoRepository.ObtenerPorIdAsync(id, ct);
            permiso.Actualizar(request.Descripcion, request.Activo);
            await permisoRepository.ActualizarAsync(permiso, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var permiso = await permisoRepository.ObtenerPorIdAsync(id, ct);
            permiso.EliminarLogico();
            await permisoRepository.EliminarAsync(permiso, ct);
        }
    }
}
