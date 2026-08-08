using SEGURIDAD.AccionSubModulo_.Web.Dominio.Entidad;

namespace SEGURIDAD.AccionSubModulo_.Web.Dominio.Interface
{
    public interface IAccionSubModuloRepository
    {
        Task<AccionSubModulo>       ObtenerPorIdAsync(Guid id,                       CancellationToken ct = default);
        Task<List<AccionSubModulo>> ListarAsync(                                     CancellationToken ct = default);
        Task                        AgregarAsync(AccionSubModulo asm,    CancellationToken ct = default);
        Task                        ActualizarAsync(AccionSubModulo asm, CancellationToken ct = default);
        Task                        EliminarAsync(AccionSubModulo asm,   CancellationToken ct = default);
    }
}
