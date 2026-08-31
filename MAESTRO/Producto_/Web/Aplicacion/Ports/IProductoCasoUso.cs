using MAESTRO.Producto_.Web.Aplicacion.DTOs;

namespace MAESTRO.Producto_.Web.Aplicacion.Ports
{
    public interface IProductoCasoUso
    {
        Task<ProductoDTO>           ObtenerPorCodigoAsync(string codigo,                            CancellationToken ct = default);
        Task<List<ProductoDTO>>     ListarAsync(                                                     CancellationToken ct = default);
        Task<List<ProductoComboDTO>> ListarComboAsync(                                              CancellationToken ct = default);
        Task                        RegistrarAsync(RegistrarProductoDTO request,                    CancellationToken ct = default);
        Task                        ActualizarAsync(string codigo, ActualizarProductoDTO request,   CancellationToken ct = default);
    }
}
