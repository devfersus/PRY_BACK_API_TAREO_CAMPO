using MAESTRO.UnidadMedida_.Web.Aplicacion.DTOs;

namespace MAESTRO.UnidadMedida_.Web.Aplicacion.Ports
{
    public interface IUnidadMedidaCasoUso
    {
        Task<UnidadMedidaDTO>            ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default);
        Task<List<UnidadMedidaDTO>>      ListarAsync(CancellationToken ct = default);
        Task<List<UnidadMedidaComboDTO>> ListarComboAsync(CancellationToken ct = default);
        Task                             RegistrarAsync(RegistrarUnidadMedidaDTO request, CancellationToken ct = default);
        Task                             ActualizarAsync(string codigo, ActualizarUnidadMedidaDTO request, CancellationToken ct = default);
    }
}
