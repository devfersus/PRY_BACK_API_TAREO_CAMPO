namespace CORE.Stock_.Web.Aplicacion.DTOs
{
    public record StockDTO(
        Guid          IdStock,
        string?       CodigoProducto,
        string?       CodigoAlmacen,
        decimal       StockActual,
        decimal       StockMinimo,
        decimal       StockMaximo,
        DateTimeOffset FechaActualizacion);
}
