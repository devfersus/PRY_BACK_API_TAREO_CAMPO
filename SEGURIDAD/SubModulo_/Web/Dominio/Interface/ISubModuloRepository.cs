using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;

namespace SEGURIDAD.SubModulo_.Web.Dominio.Interface
{
    public interface ISubModuloRepository
    {
        Task<SubModulo>       ObtenerPorIdAsync(Guid id,          CancellationToken ct = default);
        Task<List<SubModulo>> ListarAsync(                        CancellationToken ct = default);
        Task                  AgregarAsync(SubModulo subModulo,   CancellationToken ct = default);
        Task                  ActualizarAsync(SubModulo subModulo, CancellationToken ct = default);
        Task                  EliminarAsync(SubModulo subModulo,  CancellationToken ct = default);
    }
}
