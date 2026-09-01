namespace MAESTRO.Producto_.Web.Aplicacion.DTOs
{
    public record ActualizarProductoDTO(
        string?  IdCategoria,
        string?  IdProveedor,
        decimal? Precio,
        string?  Descripcion,
        string?  Comentario,
        bool     Estado,
        string?  UsuarioModificacion,
        string?  Ipv4Modificacion,
        string?  Ipv6Modificacion);
}
