namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public class CompraDetalleListadoDTO
    {
        public Guid     IdCompraDetalle      { get; set; }
        public string?  CodigoCompra         { get; set; }
        public string?  CodigoProducto       { get; set; }
        public string?  DescripcionProducto  { get; set; }
        public decimal? Unidad               { get; set; }
        public decimal? Cantidad             { get; set; }
        public string?  Comentario           { get; set; }
        public bool?    Estado               { get; set; }
    }
}
