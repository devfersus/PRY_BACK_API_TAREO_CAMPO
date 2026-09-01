namespace CORE.Ajuste_.Web.Dominio.Entidad
{
    public class AjusteDetalle
    {
        public Guid     IdAjusteDetalle     { get; private set; }
        public string?  CodigoAjuste        { get; private set; }
        public string?  CodigoAlmacen       { get; private set; }
        public string?  CodigoProducto      { get; private set; }
        public decimal? CantidadSistema     { get; private set; }
        public decimal? CantidadFisica      { get; private set; }
        public decimal? Diferencia          { get; private set; }
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

        private AjusteDetalle() { }

        public static AjusteDetalle Registrar(
            string?  codigoAjuste,
            string?  codigoAlmacen,
            string?  codigoProducto,
            decimal? cantidadSistema,
            decimal? cantidadFisica,
            decimal? diferencia,
            string?  comentario,
            bool     estado,
            string?  usuarioRegistro,
            string?  ipv4Registro,
            string?  ipv6Registro)
        {
            var ahora = DateTime.UtcNow;
            return new AjusteDetalle
            {
                IdAjusteDetalle     = Guid.NewGuid(),
                CodigoAjuste        = codigoAjuste,
                CodigoAlmacen       = codigoAlmacen,
                CodigoProducto      = codigoProducto,
                CantidadSistema     = cantidadSistema,
                CantidadFisica      = cantidadFisica,
                Diferencia          = diferencia,
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
