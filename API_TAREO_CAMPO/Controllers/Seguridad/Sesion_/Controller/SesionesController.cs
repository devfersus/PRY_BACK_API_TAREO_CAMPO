using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEGURIDAD.Infraestructura;
using SEGURIDAD.Login_.Web.Aplicacion.DTOs;
using StackExchange.Redis;

namespace API_TAREO_CAMPO.Controllers.Seguridad.Sesion_.Controller
{
    [ApiController]
    [Route("api/seguridad/sesiones")]
    public class SesionesController(
        IConnectionMultiplexer redis,
        SeguridadDBContext      ctx
    ) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<List<SesionActivaDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ObtenerSesionesActivas(CancellationToken ct)
        {
            var servidor = redis.GetServer(redis.GetEndPoints().First());
            var baseDatos = redis.GetDatabase();

            var claves   = servidor.Keys(pattern: "session:*").ToList();

            var usuarioIds = claves
                .Select(k => Guid.Parse(k.ToString().Replace("session:", "")))
                .ToList();

            if (usuarioIds.Count == 0)
                return Ok(Array.Empty<SesionActivaDTO>());

            var usuarios = await ctx.Usuarios
                .Where(u => usuarioIds.Contains(u.Id))
                .ToListAsync(ct);

            var sesiones = new List<SesionActivaDTO>();

            foreach (var usuario in usuarios)
            {
                var ttl      = await baseDatos.KeyTimeToLiveAsync($"session:{usuario.Id}");
                var expiraEn = ttl.HasValue
                    ? $"{(int)ttl.Value.TotalMinutes} min {ttl.Value.Seconds} seg"
                    : "sin expiración";

                sesiones.Add(new SesionActivaDTO(
                    usuario.Id,
                    usuario.Nombre.Value,
                    usuario.Email.Valor,
                    expiraEn));
            }

            return Ok(sesiones);
        }
    }
}
