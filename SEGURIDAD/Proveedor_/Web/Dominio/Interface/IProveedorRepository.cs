using SEGURIDAD.Proveedor_.Web.Dominio.Entidad;

namespace SEGURIDAD.Proveedor_.Web.Dominio.Interface
{
    public interface IProveedorRepository
    {
        Task<Proveedor>       ObtenerPorCodigoAsync(string codigo,        CancellationToken ct = default);
        Task<List<Proveedor>> ListarAsync(                                 CancellationToken ct = default);
        Task<List<Proveedor>> ListarActivosAsync(                          CancellationToken ct = default);
        Task                  AgregarAsync(Proveedor proveedor,            CancellationToken ct = default);
        Task                  ActualizarAsync(Proveedor proveedor,         CancellationToken ct = default);
    }
}
