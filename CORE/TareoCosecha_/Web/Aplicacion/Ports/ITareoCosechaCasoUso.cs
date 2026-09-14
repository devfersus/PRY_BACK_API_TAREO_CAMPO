using CORE.TareoCosecha_.Web.Aplicacion.DTOs;

namespace CORE.TareoCosecha_.Web.Aplicacion.Ports
{
    public interface ITareoCosechaCasoUso
    {
        Task RegistrarMasivoAsync(RegistrarTareoCosechaMasivoDTO request, CancellationToken ct = default);
    }
}
