namespace SEGURIDAD.Login_.Web.Aplicacion.Ports
{
    public interface ITokenCache
    {
        Task          GuardarSesionAsync(Guid usuarioId, string token, TimeSpan expiracion, CancellationToken ct = default);
        Task<string?> VerificarTokenAsync(Guid usuarioId, CancellationToken ct = default);

        Task                       GuardarPermisosAsync(Guid usuarioId, IEnumerable<string> claves, TimeSpan expiracion, CancellationToken ct = default);
        Task<IReadOnlySet<string>> ObtenerPermisosAsync(Guid usuarioId, CancellationToken ct = default);
        Task                       EliminarPermisosAsync(Guid usuarioId, CancellationToken ct = default);
    }
}
