using SEGURIDAD.Usuario_.Web.Aplicacion.DTOs;
using SEGURIDAD.Usuario_.Web.Aplicacion.Ports;
using SEGURIDAD.Usuario_.Web.Dominio.Entidad;
using SEGURIDAD.Usuario_.Web.Dominio.Interface;
using SEGURIDAD.Usuario_.Web.Dominio.Servicio;
using SEGURIDAD.Usuario_.Web.Dominio.ValueObject;

namespace SEGURIDAD.Usuario_.Web.Aplicacion.CasosUso
{
    public class UsuarioServicioAplicacion(
        IUsuarioRepository     usuarioRepository,
        ServicioDominioUsuario domainService
    ) : IUsuarioCasoUso
    {
        public async Task AgregarUsuario(AgregarUsuarioDTO request, CancellationToken ct = default)
        {
            var email           = Email.Agregar(request.Email);
            var nombre          = Nombre.Agregar(request.Nombre);
            var apellidoPaterno = ApellidoPaterno.Agregar(request.ApellidoPaterno);
            var apellidoMaterno = ApellidoMaterno.Agregar(request.ApellidoMaterno);

            await domainService.GarantizarEmailUnicoAsync(email, ct);

            var usuario = Usuario.Registrar(
                request.Codigo,
                nombre,
                apellidoMaterno,
                apellidoPaterno,
                email,
                request.Contraseña);

            await usuarioRepository.AgregarUsuario(usuario, ct);
        }

        public async Task<UsuarioDTO?> ObtenerPorIdUsuario(Guid id, CancellationToken ct = default)
        {
            var usuario = await usuarioRepository.ObtenerPorIdUsuario(id, ct);
            return MapearDTO(usuario);
        }

        public async Task<List<UsuarioDTO>> ListarUsuario(CancellationToken ct = default)
        {
            var usuarios = await usuarioRepository.ListarUsuario(ct);
            return usuarios.Select(MapearDTO).ToList();
        }

        public async Task<UsuarioDTO> ActualizarUsuario(Guid id, ActualizarUsuarioDTO request, CancellationToken ct = default)
        {
            var usuario = await usuarioRepository.ObtenerPorIdUsuario(id, ct);

            var nombre          = Nombre.Agregar(request.Nombre);
            var apellidoPaterno = ApellidoPaterno.Agregar(request.ApellidoPaterno);
            var apellidoMaterno = ApellidoMaterno.Agregar(request.ApellidoMaterno);
            var email           = Email.Agregar(request.Email);

            usuario.Actualizar(request.Codigo, nombre, apellidoMaterno, apellidoPaterno, email, request.Contraseña, request.Activo);

            await usuarioRepository.ActualizarUsuario(usuario, ct);

            return MapearDTO(usuario);
        }

        public async Task DesactivarUsuario(Guid id, CancellationToken ct = default)
        {
            var usuario = await usuarioRepository.ObtenerPorIdUsuario(id, ct);
            usuario.EliminarLogico();
            await usuarioRepository.ActualizarUsuario(usuario, ct);
        }

        public async Task EliminarUsuario(Guid id, CancellationToken ct = default)
        {
            var usuario = await usuarioRepository.ObtenerPorIdUsuario(id, ct);
            usuario.EliminarLogico();
            await usuarioRepository.EliminarUsuario(usuario, ct);
        }

        public async Task<List<UsuarioComboDTO>> ListarComboAsync(CancellationToken ct = default)
        {
            var usuarios = await usuarioRepository.ListarActivosAsync(ct);
            return usuarios.Select(u => new UsuarioComboDTO(
                u.Codigo,
                u.Nombre.Value,
                u.ApellidoPaterno.Value,
                u.ApellidoMaterno.Value)).ToList();
        }

        private static UsuarioDTO MapearDTO(Usuario u) =>
            new(u.Id,
                u.Codigo,
                u.Nombre.Value,
                u.ApellidoPaterno.Value,
                u.ApellidoMaterno.Value,
                u.Email.Valor,
                u.Activo,
                u.FechaCreacion,
                u.FechaModificacion);
    }
}
