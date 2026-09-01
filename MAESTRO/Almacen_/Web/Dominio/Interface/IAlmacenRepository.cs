using MAESTRO.Almacen_.Web.Dominio.Entidad;

namespace MAESTRO.Almacen_.Web.Dominio.Interface
{
    public interface IAlmacenRepository
    {
        Task<Almacen>       ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default);
        Task<List<Almacen>> ListarAsync(CancellationToken ct = default);
        Task<List<Almacen>> ListarActivosAsync(CancellationToken ct = default);
        Task                AgregarAsync(Almacen almacen, CancellationToken ct = default);
        Task                ActualizarAsync(Almacen almacen, CancellationToken ct = default);
    }
}
