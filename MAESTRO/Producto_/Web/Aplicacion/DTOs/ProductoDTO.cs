namespace MAESTRO.Producto_.Web.Aplicacion.DTOs
{
    public record ProductoDTO(
        Guid     IdProducto,
        string?  Codigo,
        string?  IdCategoria,
        string?  IdProveedor,
        decimal? Precio,
        string?  Descripcion,
        string?  Comentario,
        bool     Estado);
}
