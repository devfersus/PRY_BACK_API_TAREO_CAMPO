using SEGURIDAD.Modulo_.Web.Dominio.Entidad;

namespace SEGURIDAD.Modulo_.Web.Dominio.Interface
{
    public interface IModuloRepository
    {
        Task<Modulo>       ObtenerPorIdAsync(Guid id,      CancellationToken ct = default);
        Task<List<Modulo>> ListarAsync(                    CancellationToken ct = default);
        Task               AgregarAsync(Modulo modulo,     CancellationToken ct = default);
        Task               ActualizarAsync(Modulo modulo,  CancellationToken ct = default);
        Task               EliminarAsync(Modulo modulo,    CancellationToken ct = default);
    }
}
