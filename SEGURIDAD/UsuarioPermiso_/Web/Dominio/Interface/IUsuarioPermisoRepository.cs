using SEGURIDAD.UsuarioPermiso_.Web.Dominio.Entidad;

namespace SEGURIDAD.UsuarioPermiso_.Web.Dominio.Interface
{
    public interface IUsuarioPermisoRepository
    {
        Task<List<UsuarioPermiso>> ListarPorUsuarioAsync(Guid usuarioId, CancellationToken ct = default);
        Task<UsuarioPermiso?>      BuscarAsync(Guid usuarioId, Guid permisoId, CancellationToken ct = default);
        Task                       AgregarAsync(UsuarioPermiso usuarioPermiso, CancellationToken ct = default);
        Task                       ActualizarAsync(UsuarioPermiso usuarioPermiso, CancellationToken ct = default);
    }
}
