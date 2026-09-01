namespace CORE.Stock_.Web.Dominio.Entidad
{
    public class Stock
    {
        public Guid           IdStock            { get; private set; }
        public string?        CodigoProducto     { get; private set; }
        public string?        CodigoAlmacen      { get; private set; }
        public decimal        StockActual        { get; private set; }
        public decimal        StockMinimo        { get; private set; }
        public decimal        StockMaximo        { get; private set; }
        public DateTimeOffset FechaActualizacion { get; private set; }

        private Stock() { }

        public static Stock Crear(string? codigoProducto, string? codigoAlmacen, decimal cantidad) =>
            new()
            {
                IdStock            = Guid.NewGuid(),
                CodigoProducto     = codigoProducto,
                CodigoAlmacen      = codigoAlmacen,
                StockActual        = cantidad,
                StockMinimo        = 0,
                StockMaximo        = 0,
                FechaActualizacion = DateTimeOffset.UtcNow
            };

        public void Incrementar(decimal cantidad)
        {
            StockActual        += cantidad;
            FechaActualizacion  = DateTimeOffset.UtcNow;
        }

        public void Decrementar(decimal cantidad)
        {
            StockActual        -= cantidad;
            FechaActualizacion  = DateTimeOffset.UtcNow;
        }

        public void ConfigurarLimites(decimal minimo, decimal maximo)
        {
            StockMinimo        = minimo;
            StockMaximo        = maximo;
            FechaActualizacion = DateTimeOffset.UtcNow;
        }
    }
}
