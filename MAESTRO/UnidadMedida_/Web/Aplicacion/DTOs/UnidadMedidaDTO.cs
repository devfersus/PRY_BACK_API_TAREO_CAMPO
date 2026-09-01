namespace MAESTRO.UnidadMedida_.Web.Aplicacion.DTOs
{
    public record UnidadMedidaDTO(
        Guid    IdUnidadMedida,
        string? Codigo,
        string? Descripcion,
        string? Abreviatura,
        bool    Estado);
}
