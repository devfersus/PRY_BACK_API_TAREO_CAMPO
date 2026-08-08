using MAESTRO.Pais_.Web.Dominio.Entidad;

namespace MAESTRO.Pais_.Web.Dominio.Interface
{
    public interface IPaisRepository
    {
        Task<Pais>       ObtenerPorIdAsync(Guid id,  CancellationToken ct = default);
        Task<List<Pais>> ListarAsync(CancellationToken ct = default);
        Task             AgregarAsync(Pais pais,     CancellationToken ct = default);
        Task             ActualizarAsync(Pais pais,  CancellationToken ct = default);
        Task             EliminarAsync(Pais pais,    CancellationToken ct = default);
    }
}
