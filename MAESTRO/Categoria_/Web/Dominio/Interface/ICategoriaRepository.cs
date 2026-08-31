using MAESTRO.Categoria_.Web.Dominio.Entidad;

namespace MAESTRO.Categoria_.Web.Dominio.Interface
{
    public interface ICategoriaRepository
    {
        Task<Categoria>       ObtenerPorCodigoAsync(string codigo,        CancellationToken ct = default);
        Task<List<Categoria>> ListarAsync(                                 CancellationToken ct = default);
        Task<List<Categoria>> ListarActivosAsync(                           CancellationToken ct = default);
        Task                  AgregarAsync(Categoria categoria,            CancellationToken ct = default);
        Task                  ActualizarAsync(Categoria categoria,         CancellationToken ct = default);
    }
}
