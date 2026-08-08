using StackExchange.Redis;

namespace API_TAREO_CAMPO.Services
{
    public class RedisRequestGuard(IConnectionMultiplexer conexionRedis) : IRequestGuard
    {
        private static readonly TimeSpan duracionBloqueoIdempotencia = TimeSpan.FromSeconds(30);

        private IDatabase almacenamientoBloqueos => conexionRedis.GetDatabase();

        public async Task<bool> IntentarAdquirirBloqueoAsync(string claveIdempotencia, CancellationToken tokenCancelacion = default) =>
            await almacenamientoBloqueos.StringSetAsync($"idempotency:{claveIdempotencia}", "1", duracionBloqueoIdempotencia, When.NotExists);

        public async Task LiberarBloqueoAsync(string claveIdempotencia, CancellationToken tokenCancelacion = default) =>
            await almacenamientoBloqueos.KeyDeleteAsync($"idempotency:{claveIdempotencia}");
    }
}
