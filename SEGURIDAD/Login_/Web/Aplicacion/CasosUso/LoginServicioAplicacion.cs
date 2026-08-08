using Microsoft.Extensions.Configuration;
using SEGURIDAD.Login_.Web.Aplicacion.DTOs;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;
using SEGURIDAD.Usuario_.Web.Dominio.Interface;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Login_.Web.Aplicacion.CasosUso
{
    public class LoginServicioAplicacion(
        IUsuarioRepository usuarioRepository,
        IJwtTokenGenerator tokenGenerator,
        ITokenCache        sesionCache,
        IConfiguration     configuration
    ) : ILoginCasoUso
    {
        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request, CancellationToken ct = default)
        {
            var email   = Email.Agregar(request.Email);
            var usuario = await usuarioRepository.ObtenerPorEmailUsuario(email, ct);

            if (!usuario.Activo || usuario.Contraseña != request.Contraseña)
                throw new CredencialesInvalidasException();

            var token          = tokenGenerator.GenerarToken(usuario.Id, usuario.Email.Valor);
            var minutosExpira  = int.Parse(configuration["Jwt:ExpirationMinutes"] ?? "60");

            await sesionCache.GuardarSesionAsync(usuario.Id, token, TimeSpan.FromMinutes(minutosExpira), ct);

            return new LoginResponseDTO(token);
        }
    }
}
