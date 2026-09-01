namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public record SalidaDTO(
        Guid    IdSalida,
        string? CodigoSalida,
        string? Motivo,
        bool    Estado);
}
