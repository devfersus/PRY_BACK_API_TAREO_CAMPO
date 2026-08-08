using MAESTRO.Pais_.Web.Aplicacion.DTOs;
using MAESTRO.Pais_.Web.Aplicacion.Ports;
using MAESTRO.Pais_.Web.Dominio.Entidad;
using MAESTRO.Pais_.Web.Dominio.Interface;

namespace MAESTRO.Pais_.Web.Aplicacion.CasosUso
{
    public class PaisServicioAplicacion(IPaisRepository paisRepository) : IPaisCasoUso
    {
        public async Task<PaisDTO> ObtenerPorIdAsync(Guid id, CancellationToken ct = default)
        {
            var pais = await paisRepository.ObtenerPorIdAsync(id, ct);
            return new PaisDTO(pais.Id, pais.Descripcion, pais.Activo);
        }

        public async Task<List<PaisDTO>> ListarAsync(CancellationToken ct = default)
        {
            var paises = await paisRepository.ListarAsync(ct);
            return paises.Select(p => new PaisDTO(p.Id, p.Descripcion, p.Activo)).ToList();
        }

        public async Task RegistrarAsync(RegistrarPaisDTO request, CancellationToken ct = default)
        {
            var pais = Pais.Registrar(request.Descripcion);
            await paisRepository.AgregarAsync(pais, ct);
        }

        public async Task ActualizarAsync(Guid id, ActualizarPaisDTO request, CancellationToken ct = default)
        {
            var pais = await paisRepository.ObtenerPorIdAsync(id, ct);
            pais.Actualizar(request.Descripcion);
            await paisRepository.ActualizarAsync(pais, ct);
        }

        public async Task EliminarAsync(Guid id, CancellationToken ct = default)
        {
            var pais = await paisRepository.ObtenerPorIdAsync(id, ct);
            pais.EliminarLogico();
            await paisRepository.EliminarAsync(pais, ct);
        }
    }
}
