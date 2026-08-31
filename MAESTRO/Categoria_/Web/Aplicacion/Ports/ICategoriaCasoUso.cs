using MAESTRO.Categoria_.Web.Aplicacion.DTOs;

namespace MAESTRO.Categoria_.Web.Aplicacion.Ports
{
    public interface ICategoriaCasoUso
    {
        Task<CategoriaDTO>            ObtenerPorCodigoAsync(string codigo,                             CancellationToken ct = default);
        Task<List<CategoriaDTO>>     ListarAsync(                                                      CancellationToken ct = default);
        Task<List<CategoriaComboDTO>> ListarComboAsync(                                             CancellationToken ct = default);
        Task                          RegistrarAsync(RegistrarCategoriaDTO request,                    CancellationToken ct = default);
        Task                          ActualizarAsync(string codigo, ActualizarCategoriaDTO request,   CancellationToken ct = default);
    }
}
