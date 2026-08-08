using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.SubModulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.SubModulo_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.SubModulo_.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/submodulos")]
    public class SubModuloController(ISubModuloCasoUso subModuloCasoUso) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<List<SubModuloDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var subModulos = await subModuloCasoUso.ListarAsync(ct);
            return Ok(subModulos);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType<SubModuloDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorId(Guid id, CancellationToken ct)
        {
            var subModulo = await subModuloCasoUso.ObtenerPorIdAsync(id, ct);
            return Ok(subModulo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarSubModuloDTO request, CancellationToken ct)
        {
            await subModuloCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] Guid id, [FromBody] ActualizarSubModuloDTO request, CancellationToken ct)
        {
            await subModuloCasoUso.ActualizarAsync(id, request, ct);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Eliminar([FromQuery] Guid id, CancellationToken ct)
        {
            await subModuloCasoUso.EliminarAsync(id, ct);
            return NoContent();
        }
    }
}
