namespace MAESTRO.UnidadMedida_.Web.Aplicacion.DTOs
{
    public record RegistrarUnidadMedidaDTO(
        string? Codigo,
        string? Descripcion,
        string? Abreviatura,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
