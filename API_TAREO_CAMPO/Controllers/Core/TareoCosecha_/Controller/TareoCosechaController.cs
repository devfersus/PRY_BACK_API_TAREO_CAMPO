using CORE.TareoCosecha_.Web.Aplicacion.DTOs;
using CORE.TareoCosecha_.Web.Aplicacion.Ports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_TAREO_CAMPO.Controllers.Core.TareoCosecha_.Controller
{
    [ApiController]
    [Route("api/core/tareo-cosecha")]
    public class TareoCosechaController(ITareoCosechaCasoUso tareoCosechaCasoUso) : ControllerBase
    {
        [HttpPost("masivo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarMasivo(
            [FromBody] RegistrarTareoCosechaMasivoDTO request,
            CancellationToken ct)
        {
            await tareoCosechaCasoUso.RegistrarMasivoAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
