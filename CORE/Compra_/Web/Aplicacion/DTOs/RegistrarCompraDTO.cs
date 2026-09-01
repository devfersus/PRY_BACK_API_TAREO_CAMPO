namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public record RegistrarCompraDTO(
        string? CodigoCompra,
        string? CodigoProveedor,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
