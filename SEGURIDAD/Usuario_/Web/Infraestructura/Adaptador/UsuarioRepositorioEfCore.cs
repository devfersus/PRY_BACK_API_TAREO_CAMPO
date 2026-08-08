using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Infraestructura;
using SEGURIDAD.Usuario_.Web.Dominio.Entidad;
using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;
using SEGURIDAD.Usuario_.Web.Dominio.Interface;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Usuario_.Web.Infraestructura.Adapter
{
    public class UsuarioRepositorioEfCore : IUsuarioRepository
    {
        private readonly SeguridadDBContext _ctx;

        public UsuarioRepositorioEfCore(SeguridadDBContext ctx) => _ctx = ctx;

        public async Task<Usuario> ObtenerPorIdUsuario(Guid id, CancellationToken ct = default) =>
            await _ctx.Usuarios.FindAsync([id], ct)
            ?? throw new UsuarioNoEncontradoException(id);

        public async Task<Usuario> ObtenerPorEmailUsuario(Email email, CancellationToken ct = default) =>
            await _ctx.Usuarios
                .FirstOrDefaultAsync(u => u.Email.Valor == email.Valor, ct)
            ?? throw new CredencialesInvalidasException();
            
        public async Task<List<Usuario>> ListarUsuario(CancellationToken ct = default) =>
            await _ctx.Usuarios.ToListAsync(ct);

        public async Task<bool> ExisteEmailUsuario(Email email, CancellationToken ct = default) =>
            await _ctx.Usuarios
                .AnyAsync(u => u.Email.Valor == email.Valor, ct);

        public async Task AgregarUsuario(Usuario usuario, CancellationToken ct = default)
        {
            await _ctx.Usuarios.AddAsync(usuario, ct);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task ActualizarUsuario(Usuario usuario, CancellationToken ct = default)
        {
            _ctx.Usuarios.Update(usuario);
            await _ctx.SaveChangesAsync(ct);
        }

        public async Task EliminarUsuario(Usuario usuario, CancellationToken ct = default)
        {
            _ctx.Usuarios.Update(usuario);
            await _ctx.SaveChangesAsync(ct);
        }
    }
}
