namespace CORE.Compra_.Web.Dominio.Entidad
{
    public class CompraDetalle
    {
        public Guid     IdCompraDetalle     { get; private set; }
        public string?  CodigoCompra        { get; private set; }
        public decimal? Unidad              { get; private set; }
        public decimal? Cantidad            { get; private set; }
        public string?  CodigoProducto      { get; private set; }
        public string?  Comentario          { get; private set; }
        public bool     Estado              { get; private set; }
        public DateTime FechaRegistro       { get; private set; }
        public string?  UsuarioRegistro     { get; private set; }
        public string?  Ipv4Registro        { get; private set; }
        public string?  Ipv6Registro        { get; private set; }
        public DateTime FechaModificacion   { get; private set; }
        public string?  UsuarioModificacion { get; private set; }
        public string?  Ipv4Modificacion    { get; private set; }
        public string?  Ipv6Modificacion    { get; private set; }

        private CompraDetalle() { }

        public static CompraDetalle Registrar(
            string?  codigoCompra,
            decimal? unidad,
            decimal? cantidad,
            string?  codigoProducto,
            string?  comentario,
            bool     estado,
            string?  usuarioRegistro,
            string?  ipv4Registro,
            string?  ipv6Registro)
        {
            var ahora = DateTime.UtcNow;
            return new CompraDetalle
            {
                IdCompraDetalle     = Guid.NewGuid(),
                CodigoCompra        = codigoCompra,
                Unidad              = unidad,
                Cantidad            = cantidad,
                CodigoProducto      = codigoProducto,
                Comentario          = comentario?.Trim(),
                Estado              = estado,
                FechaRegistro       = ahora,
                UsuarioRegistro     = usuarioRegistro,
                Ipv4Registro        = ipv4Registro,
                Ipv6Registro        = ipv6Registro,
                FechaModificacion   = ahora,
                UsuarioModificacion = usuarioRegistro,
                Ipv4Modificacion    = ipv4Registro,
                Ipv6Modificacion    = ipv6Registro
            };
        }
    }
}
