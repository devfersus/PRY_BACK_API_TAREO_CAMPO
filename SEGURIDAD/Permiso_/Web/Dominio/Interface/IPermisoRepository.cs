using SEGURIDAD.Permiso_.Web.Dominio.Entidad;

namespace SEGURIDAD.Permiso_.Web.Dominio.Interface
{
    public interface IPermisoRepository
    {
        Task<Permiso>       ObtenerPorIdAsync(Guid id,       CancellationToken ct = default);
        Task<List<Permiso>> ListarAsync(                     CancellationToken ct = default);
        Task                AgregarAsync(Permiso permiso,    CancellationToken ct = default);
        Task                ActualizarAsync(Permiso permiso, CancellationToken ct = default);
        Task                EliminarAsync(Permiso permiso,   CancellationToken ct = default);
    }
}
