namespace CORE.Ajuste_.Web.Aplicacion.DTOs
{
    public class AjusteDetalleListadoDTO
    {
        public Guid     IdAjusteDetalle      { get; set; }
        public string?  CodigoAjuste         { get; set; }
        public string?  CodigoProducto       { get; set; }
        public string?  DescripcionProducto  { get; set; }
        public string?  CodigoAlmacen        { get; set; }
        public decimal? CantidadSistema      { get; set; }
        public decimal? CantidadFisica       { get; set; }
        public decimal? Diferencia           { get; set; }
        public string?  Comentario           { get; set; }
        public bool     Estado               { get; set; }
    }
}
