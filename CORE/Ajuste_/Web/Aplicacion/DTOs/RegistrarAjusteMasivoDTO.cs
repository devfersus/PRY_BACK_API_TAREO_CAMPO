namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public record RegistrarAjusteMasivoDTO(
        string?                    CodigoAjuste,
        List<AjusteDetalleItemDTO> Items,
        string?                    UsuarioRegistro,
        string?                    Ipv4Registro,
        string?                    Ipv6Registro);
}
