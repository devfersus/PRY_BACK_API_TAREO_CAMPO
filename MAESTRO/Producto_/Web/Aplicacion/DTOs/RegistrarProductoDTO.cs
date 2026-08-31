namespace MAESTRO.Producto_.Web.Aplicacion.DTOs
{
    public record RegistrarProductoDTO(
        string?  Codigo,
        string?  IdCategoria,
        string?  IdProveedor,
        decimal? Precio,
        string?  Descripcion,
        string?  Comentario,
        bool     Estado,
        string?  UsuarioRegistro,
        string?  Ipv4Registro,
        string?  Ipv6Registro);
}
