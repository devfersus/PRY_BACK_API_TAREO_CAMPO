using SEGURIDAD.Usuario_.Web.Dominio.Entidad;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Usuario_.Web.Dominio.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerPorIdUsuario(Guid id, CancellationToken ct = default);
        Task<Usuario> ObtenerPorEmailUsuario(Email email, CancellationToken ct = default);
        Task<List<Usuario>> ListarUsuario(CancellationToken ct = default);
        Task<bool> ExisteEmailUsuario(Email email, CancellationToken ct = default);
        Task AgregarUsuario(Usuario usuario, CancellationToken ct = default);
        Task ActualizarUsuario(Usuario usuario, CancellationToken ct = default);
        Task EliminarUsuario(Usuario usuario, CancellationToken ct = default);
    }
}
