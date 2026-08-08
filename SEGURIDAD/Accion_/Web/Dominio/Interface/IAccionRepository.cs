using SEGURIDAD.Accion_.Web.Dominio.Entidad;

namespace SEGURIDAD.Accion_.Web.Dominio.Interface
{
    public interface IAccionRepository
    {
        Task<Accion>       ObtenerPorIdAsync(Guid id,     CancellationToken ct = default);
        Task<List<Accion>> ListarAsync(                   CancellationToken ct = default);
        Task               AgregarAsync(Accion accion,    CancellationToken ct = default);
        Task               ActualizarAsync(Accion accion, CancellationToken ct = default);
        Task               EliminarAsync(Accion accion,   CancellationToken ct = default);
    }
}
