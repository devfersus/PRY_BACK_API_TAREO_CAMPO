using SEGURIDAD.Proveedor_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Proveedor_.Web.Aplicacion.Ports
{
    public interface IProveedorCasoUso
    {
        Task<ProveedorDTO>            ObtenerPorCodigoAsync(string codigo,                                    CancellationToken ct = default);
        Task<List<ProveedorDTO>>     ListarAsync(                                                             CancellationToken ct = default);
        Task<List<ProveedorComboDTO>> ListarComboAsync(                                                      CancellationToken ct = default);
        Task                          RegistrarAsync(RegistrarProveedorDTO request,                           CancellationToken ct = default);
        Task                          ActualizarAsync(string codigo, ActualizarProveedorDTO request,          CancellationToken ct = default);
    }
}
