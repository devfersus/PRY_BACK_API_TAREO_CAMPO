namespace API_TAREO_CAMPO.Services
{
    public interface IRequestGuard
    {
        Task<bool> IntentarAdquirirBloqueoAsync(string claveIdempotencia, CancellationToken tokenCancelacion = default);
        Task LiberarBloqueoAsync(string claveIdempotencia, CancellationToken tokenCancelacion = default);
    }
}
