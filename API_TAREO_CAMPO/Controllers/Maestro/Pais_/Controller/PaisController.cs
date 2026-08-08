using MAESTRO.Pais_.Web.Aplicacion.DTOs;
using MAESTRO.Pais_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Maestro.Pais_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/maestro/paises")]
    public class PaisController(IPaisCasoUso paisCasoUso) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<List<PaisDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var paises = await paisCasoUso.ListarAsync(ct);
            return Ok(paises);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType<PaisDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(Guid id, CancellationToken ct)
        {
            var pais = await paisCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(pais);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPaisDTO request, CancellationToken ct)
        {
            await paisCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] ActualizarPaisDTO request, CancellationToken ct)
        {
            await paisCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar(Guid id, CancellationToken ct)
        {
            await paisCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
