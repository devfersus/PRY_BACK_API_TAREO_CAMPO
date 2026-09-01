namespace SEGURIDAD.Proveedor_.Web.Aplicacion.DTOs
{
    public record RegistrarProveedorDTO(
        string? Codigo,
        string? Descripcion,
        string? Comentario,
        string? CodigoUsuario,
        bool    Estado,
        string? UsuarioRegistro,
        string? Ipv4Registro,
        string? Ipv6Registro);
}
