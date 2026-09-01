namespace MAESTRO.Categoria_.Web.Aplicacion.DTOs
{
    public record RegistrarCategoriaDTO(
        string? Codigo,
        string? Descripcion,
        string? Comentario,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
