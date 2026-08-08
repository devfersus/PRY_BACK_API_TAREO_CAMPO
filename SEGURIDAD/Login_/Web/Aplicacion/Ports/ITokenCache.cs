namespace SEGURIDAD.Login_.Web.Aplicacion.Ports
{
    public interface ITokenCache
    {
        Task GuardarSesionAsync(Guid usuarioId, string token, TimeSpan expiracion, CancellationToken ct = default);
        Task<string?> VerificarTokenAsync(Guid usuarioId, CancellationToken ct = default);
    }
}
