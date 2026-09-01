namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public record RegistrarCompraMasivoDTO(
        string?                    CodigoCompra,
        string?                    CodigoProveedor,
        List<CompraDetalleItemDTO> Items,
        string?                    UsuarioRegistro,
        string?                    Ipv4Registro,
        string?                    Ipv6Registro);
}
