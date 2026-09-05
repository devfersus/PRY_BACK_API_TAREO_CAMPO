using Microsoft.Extensions.Configuration;
using SEGURIDAD.Login_.Web.Aplicacion.DTOs;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using SEGURIDAD.Usuario_.Web.Dominio.Exceptions;
using SEGURIDAD.Usuario_.Web.Dominio.Interface;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;
using SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.Ports;

namespace SEGURIDAD.Login_.Web.Aplicacion.CasosUso
{
    public class LoginServicioAplicacion(
        IUsuarioRepository              usuarioRepository,
        IJwtTokenGenerator              tokenGenerator,
        ITokenCache                     sesionCache,
        IConfiguration                  configuration,
        IPermisoUsuarioConsultaServicio permisoConsulta
    ) : ILoginCasoUso
    {
        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request, CancellationToken ct = default)
        {
            var email   = Email.Agregar(request.Email);
            var usuario = await usuarioRepository.ObtenerPorEmailUsuario(email, ct);

            if (!usuario.Activo || usuario.Contraseña != request.Contraseña)
                throw new CredencialesInvalidasException();

            var token         = tokenGenerator.GenerarToken(usuario.Id, usuario.Email.Valor);
            var minutosExpira = int.Parse(configuration["Jwt:ExpirationMinutes"] ?? "60");
            var ttl           = TimeSpan.FromMinutes(minutosExpira);

            await sesionCache.GuardarSesionAsync(usuario.Id, token, ttl, ct);

            var claves = await permisoConsulta.ObtenerClavesPermisoAsync(usuario.Id, ct);
            await sesionCache.GuardarPermisosAsync(usuario.Id, claves, ttl, ct);

            return new LoginResponseDTO(token);
        }
    }
}
