using SEGURIDAD.Permiso_.Web.Aplicacion.DTOs;
using SEGURIDAD.Permiso_.Web.Aplicacion.Ports;
using SEGURIDAD.Permiso_.Web.Dominio.Entidad;
using SEGURIDAD.Permiso_.Web.Dominio.Exceptions;
using SEGURIDAD.Permiso_.Web.Dominio.Interface;

namespace SEGURIDAD.Permiso_.Web.Aplicacion.CasosUso
{
    public class PermisoDetalleServicioAplicacion(IPermisoDetalleRepository permisoDetalleRepository) : IPermisoDetalleCasoUso
    {
        public async Task<List<PermisoDetalleDTO>> ListarPorPermisoAsync(Guid permisoId, CancellationToken ct = default)
        {
            var detalles = await permisoDetalleRepository.ListarPorPermisoAsync(permisoId, ct);
            return detalles.Select(pd => new PermisoDetalleDTO(
                pd.Id,
                pd.PermisoId,
                pd.ModuloId,    pd.Modulo?.Descripcion    ?? string.Empty,
                pd.SubModuloId, pd.SubModulo?.Descripcion ?? string.Empty,
                pd.AccionId,    pd.Accion?.Descripcion    ?? string.Empty,
                pd.Activo
            )).ToList();
        }

        public async Task RegistrarAsync(RegistrarPermisoDetallesDTO request, CancellationToken ct = default)
        {
            var nuevos = new List<PermisoDetalle>();

            foreach (var d in request.Detalles)
            {
                if (await permisoDetalleRepository.ExisteCombinacionSinAccionAsync(
                        request.PermisoId, d.ModuloId, d.SubModuloId, ct))
                    throw new PermisoDetalleDuplicadoException();

                var existente = await permisoDetalleRepository.BuscarPorCombinacionAsync(
                    request.PermisoId, d.ModuloId, d.SubModuloId, d.AccionId, ct);

                if (existente is null)
                    nuevos.Add(PermisoDetalle.Registrar(request.PermisoId, d.ModuloId, d.SubModuloId, d.AccionId));
                else
                    existente.Actualizar(d.ModuloId, d.SubModuloId, d.AccionId, true);
            }

            await permisoDetalleRepository.AgregarRangoAsync(nuevos, ct);
        }

        public async Task ActualizarAsync(List<ActualizarPermisoDetalleDTO> request, CancellationToken ct = default)
        {
            var nuevos = new List<PermisoDetalle>();

            foreach (var item in request)
            {
                var detalle = await permisoDetalleRepository.BuscarPorCombinacionAsync(
                    item.PermisoId,item.ModuloId, item.SubModuloId, item.AccionId, ct);

                if (detalle is null)
                    nuevos.Add(PermisoDetalle.Registrar(item.PermisoId, item.ModuloId, item.SubModuloId, item.AccionId));
                else
                    detalle.Actualizar(item.ModuloId, item.SubModuloId, item.AccionId, item.Activo);
            }

            await permisoDetalleRepository.AgregarRangoAsync(nuevos, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var detalle = await permisoDetalleRepository.ObtenerPorIdAsync(id, ct);
            detalle.EliminarLogico();
            await permisoDetalleRepository.EliminarAsync(detalle, ct);
        }
    }
}
