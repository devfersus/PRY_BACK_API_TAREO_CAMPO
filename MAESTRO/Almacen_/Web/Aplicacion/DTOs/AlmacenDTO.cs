namespace MAESTRO.Almacen_.Web.Aplicacion.DTOs
{
    public record AlmacenDTO(
        Guid    IdAlmacen,
        string? Codigo,
        string? Descripcion,
        string? Ubicacion,
        bool    Estado);
}
