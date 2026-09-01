namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public class AjusteListadoDTO
    {
        public Guid    IdAjuste     { get; set; }
        public string? CodigoAjuste { get; set; }
        public string? Motivo       { get; set; }
        public bool    Estado       { get; set; }
    }
}
