namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public record CompraDTO(
        Guid    IdCompra,
        string? CodigoCompra,
        string? CodigoProveedor,
        bool    Estado);
}
