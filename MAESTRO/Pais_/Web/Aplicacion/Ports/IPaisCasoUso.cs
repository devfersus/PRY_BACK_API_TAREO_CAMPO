using MAESTRO.Pais_.Web.Aplicacion.DTOs;

namespace MAESTRO.Pais_.Web.Aplicacion.Ports
{
    public interface IPaisCasoUso
    {
        Task<PaisDTO>       ObtenerPorIdAsync(Guid id,                              CancellationToken ct = default);
        Task<List<PaisDTO>> ListarAsync(                                             CancellationToken ct = default);
        Task                RegistrarAsync(RegistrarPaisDTO  request,               CancellationToken ct = default);
        Task                ActualizarAsync(Guid id, ActualizarPaisDTO request,     CancellationToken ct = default);
        Task                EliminarAsync(Guid id,                                  CancellationToken ct = default);
    }
}
