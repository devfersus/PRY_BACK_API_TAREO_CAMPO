using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.Ports
{
    public interface IUsuarioPermisoCasoUso
    {
        Task<List<UsuarioPermisoDTO>> ListarPorUsuarioAsync(Guid usuarioId, CancellationToken ct = default);
        Task                          AsignarAsync(AsignarUsuarioPermisoDTO request, CancellationToken ct = default);
        Task                          RevocarAsync(Guid usuarioId, Guid permisoId, CancellationToken ct = default);
    }
}
