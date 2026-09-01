using API_TAREO_CAMPO.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Usuario_.Web.Aplicacion.DTOs;
using SEGURIDAD.Usuario_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Usuario.CasosUso.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/usuarios")]
    public class UsuarioController(IUsuarioCasoUso casoUso) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var usuarios = await casoUso.ListarUsuario(ct);
            return Ok(usuarios);
        }

        [HttpGet("combo")]
        [ProducesResponseType<List<UsuarioComboDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Combo(CancellationToken ct)
        {
            var combo = await casoUso.ListarComboAsync(ct);
            return Ok(combo);
        }

        [HttpGet("detalle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId([FromQuery] Guid id, CancellationToken ct)
        {
            var usuario = await casoUso.ObtenerPorIdUsuario(id, ct);
            return Ok(usuario);
        }

        [HttpPost]
        [ServiceFilter(typeof(EmailRequestGuardFilter))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Crear([FromBody] AgregarUsuarioDTO request, CancellationToken ct)
        {
            await casoUso.AgregarUsuario(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarUsuarioDTO request, CancellationToken ct)
        {
            await casoUso.ActualizarUsuario(id, request, ct);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar([FromQuery] Guid id, CancellationToken ct)
        {
            await casoUso.EliminarUsuario(id, ct);
            return NoContent();
        }
    }
}
