namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public record SalidaDetalleItemDTO(
        string?  CodigoAlmacen,
        string?  CodigoProducto,
        decimal? Unidad,
        decimal? Cantidad,
        string?  Comentario,
        bool     Estado);
}
