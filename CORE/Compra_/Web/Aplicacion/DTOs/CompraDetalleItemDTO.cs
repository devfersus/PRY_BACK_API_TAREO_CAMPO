namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public record CompraDetalleItemDTO(
        decimal? Unidad,
        decimal? Cantidad,
        string?  CodigoProducto,
        string?  Comentario,
        bool     Estado);
}
