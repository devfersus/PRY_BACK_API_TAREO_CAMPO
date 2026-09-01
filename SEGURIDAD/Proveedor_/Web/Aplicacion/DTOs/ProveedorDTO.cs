namespace SEGURIDAD.Proveedor_.Web.Aplicacion.DTOs
{
    public record ProveedorDTO(
        Guid    IdProveedor,
        string? Codigo,
        string? Descripcion,
        string? Comentario,
        string? CodigoUsuario,
        bool    Estado);
}
