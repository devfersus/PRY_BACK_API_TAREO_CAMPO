using SEGURIDAD.Login_.Web.Aplicacion.Ports;
using StackExchange.Redis;

namespace API_TAREO_CAMPO.Redis
{
    public class RedisTokenCache(IConnectionMultiplexer conexionRedis) : ITokenCache
    {
        private IDatabase Db => conexionRedis.GetDatabase();

        public async Task GuardarSesionAsync(Guid usuarioId, string token, TimeSpan expiracion, CancellationToken tokenCancelacion = default)
            => await Db.StringSetAsync($"session:{usuarioId}", token, expiracion);

        public async Task<string?> VerificarTokenAsync(Guid usuarioId, CancellationToken tokenCancelacion = default)
            => await Db.StringGetAsync($"session:{usuarioId}");

        public async Task GuardarPermisosAsync(Guid usuarioId, IEnumerable<string> claves, TimeSpan expiracion, CancellationToken ct = default)
        {
            var clave   = $"permisos:{usuarioId}";
            var valores = claves.Select(c => (RedisValue)c).ToArray();

            await Db.KeyDeleteAsync(clave);

            if (valores.Length > 0)
            {
                await Db.SetAddAsync(clave, valores);
                await Db.KeyExpireAsync(clave, expiracion);
            }
        }

        public async Task<IReadOnlySet<string>> ObtenerPermisosAsync(Guid usuarioId, CancellationToken ct = default)
        {
            var valores = await Db.SetMembersAsync($"permisos:{usuarioId}");
            return valores.Select(v => v.ToString()).ToHashSet();
        }

        public async Task EliminarPermisosAsync(Guid usuarioId, CancellationToken ct = default)
            => await Db.KeyDeleteAsync($"permisos:{usuarioId}");
    }
}
