namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public record RegistrarSalidaDTO(
        string? CodigoSalida,
        string? Motivo,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
