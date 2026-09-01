namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public record AjusteDetalleItemDTO(
        string?  CodigoAlmacen,
        string?  CodigoProducto,
        decimal? CantidadSistema,
        decimal? CantidadFisica,
        string?  Comentario,
        bool     Estado);
}
