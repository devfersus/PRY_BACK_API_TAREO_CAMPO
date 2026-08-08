using SEGURIDAD.Login_.Web.Aplicacion.DTOs;

namespace SEGURIDAD.Login_.Web.Aplicacion.Ports
{
    public interface ILoginCasoUso
    {
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request, CancellationToken ct = default);
    }
}
