using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Login_.Web.Aplicacion.DTOs;
using SEGURIDAD.Login_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Login.CasosUso.Auth.Controller
{
    [ApiController]
    [Route("api/seguridad/auth")]
    public class AuthController(ILoginCasoUso loginCasoUso) : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType<LoginResponseDTO>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request, CancellationToken ct)
        {
            var response = await loginCasoUso.LoginAsync(request, ct);
            return Ok(response);
        }
    }
}
