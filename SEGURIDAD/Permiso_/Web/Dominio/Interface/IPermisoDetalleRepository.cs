using SEGURIDAD.Permiso_.Web.Dominio.Entidad;

namespace SEGURIDAD.Permiso_.Web.Dominio.Interface
{
    public interface IPermisoDetalleRepository
    {
        Task<List<PermisoDetalle>> ListarPorPermisoAsync(Guid permisoId, CancellationToken ct = default);
        Task                       AgregarRangoAsync(List<PermisoDetalle> detalles, CancellationToken ct = default);
        Task<PermisoDetalle>       ObtenerPorIdAsync(Guid id, CancellationToken ct = default);
        Task<PermisoDetalle?>      BuscarPorCombinacionAsync(Guid permisoId ,Guid moduloId, Guid subModuloId, Guid accionId, CancellationToken ct = default);
        Task<bool>                 ExisteCombinacionSinAccionAsync(Guid permisoId, Guid moduloId, Guid subModuloId, CancellationToken ct = default);
        Task                       ActualizarAsync(PermisoDetalle detalle, CancellationToken ct = default);
        Task                       EliminarAsync(PermisoDetalle detalle, CancellationToken ct = default);
    }
}
