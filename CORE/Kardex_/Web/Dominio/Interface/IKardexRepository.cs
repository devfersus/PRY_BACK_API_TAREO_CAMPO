using CORE.Kardex_.Web.Dominio.Entidad;

namespace CORE.Kardex_.Web.Dominio.Interface
{
    public interface IKardexRepository
    {
        Task<List<Kardex>> ListarAsync(CancellationToken ct = default);
        Task<List<Kardex>> ListarPorProductoAlmacenAsync(string codigoProducto, string? codigoAlmacen, CancellationToken ct = default);
        Task               AgregarAsync(Kardex kardex, CancellationToken ct = default);
    }
}
