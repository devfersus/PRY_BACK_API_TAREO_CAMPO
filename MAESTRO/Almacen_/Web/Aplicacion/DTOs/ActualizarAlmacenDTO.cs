namespace MAESTRO.Almacen_.Web.Aplicacion.DTOs
{
    public record ActualizarAlmacenDTO(
        string? Descripcion,
        string? Ubicacion,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
