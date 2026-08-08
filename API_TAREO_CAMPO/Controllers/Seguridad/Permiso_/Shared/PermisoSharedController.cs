using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEGURIDAD.Accion_.Web.Aplicacion.DTOs;
using SEGURIDAD.Accion_.Web.Aplicacion.Ports;
using SEGURIDAD.Modulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.Modulo_.Web.Aplicacion.Ports;
using SEGURIDAD.SubModulo_.Web.Aplicacion.DTOs;
using SEGURIDAD.SubModulo_.Web.Aplicacion.Ports;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Permiso_.Shared
{
    [ApiController]
    [Authorize]
    [Route("api/seguridad/permisos/shared")]
    public class PermisoSharedController(
        IModuloCasoUso    moduloCasoUso,
        ISubModuloCasoUso subModuloCasoUso,
        IAccionCasoUso    accionCasoUso) : ControllerBase
    {
        [HttpGet("modulos")]
        [ProducesResponseType<List<ModuloDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerModulos(CancellationToken ct)
        {
            var modulos = await moduloCasoUso.ListarAsync(ct);
            return Ok(modulos);
        }

        [HttpGet("submodulos")]
        [ProducesResponseType<List<SubModuloDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerSubModulos(CancellationToken ct)
        {
            var subModulos = await subModuloCasoUso.ListarAsync(ct);
            return Ok(subModulos);
        }

        [HttpGet("acciones")]
        [ProducesResponseType<List<AccionDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerAcciones(CancellationToken ct)
        {
            var acciones = await accionCasoUso.ListarAsync(ct);
            return Ok(acciones);
        }
    }
}
