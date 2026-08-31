namespace MAESTRO.Categoria_.Web.Aplicacion.DTOs
{
    public record ActualizarCategoriaDTO(
        string? Descripcion,
        string? Comentario,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
