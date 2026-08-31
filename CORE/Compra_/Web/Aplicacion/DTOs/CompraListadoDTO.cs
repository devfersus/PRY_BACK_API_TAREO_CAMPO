namespace CORE.Compra_.Web.Aplicacion.DTOs
{
    public class CompraListadoDTO
    {
        public Guid    IdCompra             { get; set; }
        public string? CodigoCompra         { get; set; }
        public string? CodigoProveedor      { get; set; }
        public string? DescripcionProveedor { get; set; }
        public bool    Estado               { get; set; }
    }
}
