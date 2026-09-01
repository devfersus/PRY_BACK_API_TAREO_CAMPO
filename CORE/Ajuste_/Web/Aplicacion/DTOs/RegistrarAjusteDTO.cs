namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public record RegistrarAjusteDTO(
        string? CodigoAjuste,
        string? Motivo,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
