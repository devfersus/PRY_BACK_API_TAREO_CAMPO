using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;
using SEGURIDAD.Usuario_.Web.Dominio.Interface;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Usuario_.Web.Dominio.Servicio
{
    public class ServicioDominioUsuario(
        IUsuarioRepository usuarioRepository
    )
    {

        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        public async Task GarantizarEmailUnicoAsync(Email email, CancellationToken ct = default)
        {
            if (await _usuarioRepository.ExisteEmailUsuario(email, ct))
                throw new DominiIoExceptionUsuario($"Ya existe un usuario con el email '{email}'.");
        }
    }
}