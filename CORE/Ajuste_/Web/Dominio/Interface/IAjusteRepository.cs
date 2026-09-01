using CORE.Ajuste_.Web.Aplicacion.DTOs;
using CORE.Ajuste_.Web.Dominio.Entidad;

namespace CORE.Ajuste_.Web.Dominio.Interface
{
    public interface IAjusteRepository
    {
        Task<Ajuste>                        ObtenerPorIdAsync(Guid id,                                           CancellationToken ct = default);
        Task<List<AjusteListadoDTO>>        ListarAsync(                                                         CancellationToken ct = default);
        Task                                AgregarAsync(Ajuste ajuste,                                          CancellationToken ct = default);
        Task                                ActualizarAsync(Ajuste ajuste,                                       CancellationToken ct = default);
        Task                                AgregarDetallesMasivoAsync(List<AjusteDetalle> detalles,             CancellationToken ct = default);
        Task<List<AjusteDetalleListadoDTO>> ListarDetallesAsync(string? codigoAjuste,                            CancellationToken ct = default);
    }
}
