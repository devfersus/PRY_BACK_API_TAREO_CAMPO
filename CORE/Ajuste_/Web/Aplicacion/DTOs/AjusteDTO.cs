namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public record AjusteDTO(
        Guid    IdAjuste,
        string? CodigoAjuste,
        string? Motivo,
        bool    Estado);
}
