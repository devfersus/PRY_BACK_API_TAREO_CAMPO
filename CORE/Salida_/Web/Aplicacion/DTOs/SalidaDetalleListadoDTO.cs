namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public class SalidaDetalleListadoDTO
    {
        public Guid     IdSalidaDetalle      { get; set; }
        public string?  CodigoSalida         { get; set; }
        public string?  CodigoProducto       { get; set; }
        public string?  DescripcionProducto  { get; set; }
        public decimal? Unidad               { get; set; }
        public decimal? Cantidad             { get; set; }
        public string?  Comentario           { get; set; }
        public bool     Estado               { get; set; }
    }
}
