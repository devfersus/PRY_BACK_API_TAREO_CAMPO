namespace MAESTRO.Almacen_.Web.Aplicacion.DTOs
{
    public record RegistrarAlmacenDTO(
        string? Codigo,
        string? Descripcion,
        string? Ubicacion,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
