using CORE.Salida_.Web.Aplicacion.DTOs;
using CORE.Salida_.Web.Dominio.Entidad;

namespace CORE.Salida_.Web.Dominio.Interface
{
    public interface ISalidaRepository
    {
        Task<Salida>                       ObtenerPorIdAsync(Guid id,                                                               CancellationToken ct = default);
        Task<List<SalidaListadoDTO>>        ListarAsync(                                                                             CancellationToken ct = default);
        Task                                AgregarAsync(Salida salida,                                                              CancellationToken ct = default);
        Task                                ActualizarAsync(Salida salida,                                                           CancellationToken ct = default);
        Task                                AgregarDetallesMasivoAsync(List<SalidaDetalle> detalles,                                 CancellationToken ct = default);
        Task<List<SalidaDetalleListadoDTO>> ListarDetallesAsync(string? codigoSalida,                                                CancellationToken ct = default);
    }
}
