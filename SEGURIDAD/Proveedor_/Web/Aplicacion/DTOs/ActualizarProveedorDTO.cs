namespace SEGURIDAD.Proveedor_.Web.Aplicacion.DTOs
{
    public record ActualizarProveedorDTO(
        string? Descripcion,
        string? Comentario,
        string? CodigoUsuario,
        bool    Estado,
        string? UsuarioModificacion,
        string? Ipv4Modificacion,
        string? Ipv6Modificacion);
}
