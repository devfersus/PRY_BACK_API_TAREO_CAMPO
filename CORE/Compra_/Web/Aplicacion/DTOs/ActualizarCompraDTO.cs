namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public record ActualizarCompraDTO(
        string? CodigoProveedor,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
