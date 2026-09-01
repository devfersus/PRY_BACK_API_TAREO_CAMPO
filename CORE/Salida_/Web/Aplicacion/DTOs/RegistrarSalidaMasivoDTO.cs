namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public record RegistrarSalidaMasivoDTO(
        string?                     CodigoSalida,
        List<SalidaDetalleItemDTO>  Items,
        string?                     UsuarioRegistro,
        string?                     Ipv4Registro,
        string?                     Ipv6Registro);
}
