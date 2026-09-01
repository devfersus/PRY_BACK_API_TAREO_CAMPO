using MAESTRO.UnidadMedida_.Web.Dominio.Entidad;

namespace MAESTRO.UnidadMedida_.Web.Dominio.Interface
{
    public interface IUnidadMedidaRepository
    {
        Task<UnidadMedida>       ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default);
        Task<List<UnidadMedida>> ListarAsync(CancellationToken ct = default);
        Task<List<UnidadMedida>> ListarActivosAsync(CancellationToken ct = default);
        Task                     AgregarAsync(UnidadMedida unidadMedida, CancellationToken ct = default);
        Task                     ActualizarAsync(UnidadMedida unidadMedida, CancellationToken ct = default);
    }
}
