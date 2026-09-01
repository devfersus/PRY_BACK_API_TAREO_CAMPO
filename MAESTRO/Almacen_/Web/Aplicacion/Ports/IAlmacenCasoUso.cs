using MAESTRO.Almacen_.Web.Aplicacion.DTOs;

namespace MAESTRO.Almacen_.Web.Aplicacion.Ports
{
    public interface IAlmacenCasoUso
    {
        Task<AlmacenDTO>            ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default);
        Task<List<AlmacenDTO>>      ListarAsync(CancellationToken ct = default);
        Task<List<AlmacenComboDTO>> ListarComboAsync(CancellationToken ct = default);
        Task                        RegistrarAsync(RegistrarAlmacenDTO request, CancellationToken ct = default);
        Task                        ActualizarAsync(string codigo, ActualizarAlmacenDTO request, CancellationToken ct = default);
    }
}
