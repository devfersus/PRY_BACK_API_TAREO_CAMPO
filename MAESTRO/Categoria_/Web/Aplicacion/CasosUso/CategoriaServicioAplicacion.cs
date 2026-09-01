using MAESTRO.Categoria_.Web.Aplicacion.DTOs;
using MAESTRO.Categoria_.Web.Aplicacion.Ports;
using MAESTRO.Categoria_.Web.Dominio.Entidad;
using MAESTRO.Categoria_.Web.Dominio.Interface;

namespace MAESTRO.Categoria_.Web.Aplicacion.CasosUso
{
    public class CategoriaServicioAplicacion(ICategoriaRepository categoriaRepository) : ICategoriaCasoUso
    {
        public async Task<CategoriaDTO> ObtenerPorCodigoAsync(string codigo, CancellationToken ct = default)
        {
            var categoria = await categoriaRepository.ObtenerPorCodigoAsync(codigo, ct);
            return ToDTO(categoria);
        }

        public async Task<List<CategoriaDTO>> ListarAsync(CancellationToken ct = default)
        {
            var categorias = await categoriaRepository.ListarAsync(ct);
            return categorias.Select(ToDTO).ToList();
        }

        public async Task<List<CategoriaComboDTO>> ListarComboAsync(CancellationToken ct = default)
        {
            var categorias = await categoriaRepository.ListarActivosAsync(ct);
            return categorias.Select(c => new CategoriaComboDTO(c.Codigo, c.Descripcion)).ToList();
        }

        public async Task RegistrarAsync(RegistrarCategoriaDTO request, CancellationToken ct = default)
        {
            var categoria = Categoria.Registrar(
                request.Codigo,
                request.Descripcion,
                request.Comentario,
                request.Estado,
                request.UsuarioRegistro,
                request.Ipv4Registro,
                request.Ipv6Registro);

            await categoriaRepository.AgregarAsync(categoria, ct);
        }

        public async Task ActualizarAsync(string codigo, ActualizarCategoriaDTO request, CancellationToken ct = default)
        {
            var categoria = await categoriaRepository.ObtenerPorCodigoAsync(codigo, ct);

            categoria.Actualizar(
                request.Descripcion,
                request.Comentario,
                request.Estado,
                request.UsuarioModificacion,
                request.Ipv4Modificacion,
                request.Ipv6Modificacion);

            await categoriaRepository.ActualizarAsync(categoria, ct);
        }

        private static CategoriaDTO ToDTO(Categoria c) =>
            new(c.IdCategoria, c.Codigo, c.Descripcion, c.Comentario, c.Estado);
    }
}
