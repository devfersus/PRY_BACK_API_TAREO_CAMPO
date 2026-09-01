namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public record ActualizarAjusteDTO(
        string? Motivo,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
