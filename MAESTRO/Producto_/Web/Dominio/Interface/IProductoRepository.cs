using MAESTRO.Producto_.Web.Dominio.Entidad;

namespace MAESTRO.Producto_.Web.Dominio.Interface
{
    public interface IProductoRepository
    {
        Task<Producto>       ObtenerPorCodigoAsync(string codigo,     CancellationToken ct = default);
        Task<List<Producto>> ListarAsync(                              CancellationToken ct = default);
        Task<List<Producto>> ListarActivosAsync(                       CancellationToken ct = default);
        Task                 AgregarAsync(Producto producto,           CancellationToken ct = default);
        Task                 ActualizarAsync(Producto producto,        CancellationToken ct = default);
    }
}
