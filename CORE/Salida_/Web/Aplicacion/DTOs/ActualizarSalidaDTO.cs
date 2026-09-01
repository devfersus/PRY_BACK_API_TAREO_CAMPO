namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public record ActualizarSalidaDTO(
        string? Motivo,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
