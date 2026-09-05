using API_TAREO_CAMPO.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Proveedor_.Web.Aplicacion.DTOs;
using SEGURIDAD.Proveedor_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Proveedor_.Controller
{
    [ApiController]
    [Route("api/seguridad/proveedores")]
    public class ProveedorController(IProveedorCasoUso proveedorCasoUso) : ControllerBase
    {
        [HttpGet("listar")]
        [RequirePermiso("SEGURIDAD", "PROVEEDOR", "LISTAR")]
        [ProducesResponseType<List<ProveedorDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Listar(CancellationToken ct)
        {
            var proveedores = await proveedorCasoUso.ListarAsync(ct);
            return Ok(proveedores);
        }

        [HttpGet("combo")]
        [RequirePermiso("SEGURIDAD", "PROVEEDOR", "LISTAR")]
        [ProducesResponseType<List<ProveedorComboDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> Combo(CancellationToken ct)
        {
            var combo = await proveedorCasoUso.ListarComboAsync(ct);
            return Ok(combo);
        }

        [HttpGet]
        [RequirePermiso("SEGURIDAD", "PROVEEDOR", "LISTAR")]
        [ProducesResponseType<ProveedorDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ObtenerPorCodigo([FromQuery] string codigo, CancellationToken ct)
        {
            var proveedor = await proveedorCasoUso.ObtenerPorCodigoAsync(codigo, ct);
            return Ok(proveedor);
        }

        [HttpPost]
        [RequirePermiso("SEGURIDAD", "PROVEEDOR", "REGISTRAR")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Registrar([FromBody] RegistrarProveedorDTO request, CancellationToken ct)
        {
            await proveedorCasoUso.RegistrarAsync(request, ct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [RequirePermiso("SEGURIDAD", "PROVEEDOR", "EDITAR")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Actualizar([FromQuery] string codigo, [FromBody] ActualizarProveedorDTO request, CancellationToken ct)
        {
            await proveedorCasoUso.ActualizarAsync(codigo, request, ct);
            return NoContent();
        }
    }
}
