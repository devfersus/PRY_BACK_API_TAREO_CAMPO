using CORE.TareoCosecha_.Web.Dominio.Entidad;

namespace CORE.TareoCosecha_.Web.Dominio.Interface
{
    public interface ITareoCosechaRepository
    {
        Task AgregarMasivoAsync(List<TareoCosecha> registros, CancellationToken ct = default);
    }
}
