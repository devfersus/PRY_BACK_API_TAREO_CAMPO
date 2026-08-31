using SEGURIDAD.Usuario_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Usuario_.Web.Aplicacion.Ports
{
    public interface IUsuarioCasoUso
    {
        Task AgregarUsuario(AgregarUsuarioDTO request, CancellationToken ct = default);
        Task<UsuarioDTO?> ObtenerPorIdUsuario(Guid id, CancellationToken ct = default);
        Task<List<UsuarioDTO>> ListarUsuario(CancellationToken ct = default);
        Task<List<UsuarioComboDTO>> ListarComboAsync(CancellationToken ct = default);
        Task<UsuarioDTO> ActualizarUsuario(Guid id, ActualizarUsuarioDTO request, CancellationToken ct = default);
        Task DesactivarUsuario(Guid id, CancellationToken ct = default);
        Task EliminarUsuario(Guid id, CancellationToken ct = default);
    }
}
