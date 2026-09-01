namespace MAESTRO.UnidadMedida_.Web.Aplicacion.DTOs
{
    public record ActualizarUnidadMedidaDTO(
        string? Descripcion,
        string? Abreviatura,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
