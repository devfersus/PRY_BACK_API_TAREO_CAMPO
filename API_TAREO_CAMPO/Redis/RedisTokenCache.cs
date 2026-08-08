using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using StackExchange.Redis;

namespace API_TAREO_CAMPO.Redis
{
    public class RedisTokenCache(IConnectionMultiplexer conexionRedis) : ITokenCache
    {
        private IDatabase almacenamientoTokens => conexionRedis.GetDatabase();

        public async Task GuardarSesionAsync(Guid usuarioId, string token, TimeSpan expiracion, CancellationToken tokenCancelacion = default)
            => await almacenamientoTokens.StringSetAsync($"session:{usuarioId}", token, expiracion);

        public async Task<string?> VerificarTokenAsync(Guid usuarioId, CancellationToken tokenCancelacion = default)
            => await almacenamientoTokens.StringGetAsync($"session:{usuarioId}");
    }
}
