namespace MAESTRO.Categoria_.Web.Aplicacion.DTOs
{
    public record CategoriaDTO(
        Guid    IdCategoria,
        string? Codigo,
        string? Descripcion,
        string? Comentario,
        bool    Estado);
}
