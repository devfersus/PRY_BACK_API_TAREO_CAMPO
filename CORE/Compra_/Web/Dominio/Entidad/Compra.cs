namespace CORE.Compra_.Web.Dominio.Entidad
{
    public class Compra
    {
        public Guid    IdCompra            { get; private set; }
        public string? CodigoCompra        { get; private set; }
        public string? CodigoProveedor     { get; private set; }
        public bool    Estado              { get; private set; }
        public DateTime FechaRegistro       { get; private set; }
        public string? UsuarioRegistro     { get; private set; }
        public string? Ipv4Registro        { get; private set; }
        public string? Ipv6Registro        { get; private set; }
        public DateTime FechaModificacion   { get; private set; }
        public string? UsuarioModificacion { get; private set; }
        public string? Ipv4Modificacion    { get; private set; }
        public string? Ipv6Modificacion    { get; private set; }

        private Compra() { }

        public static Compra Registrar(
            string? codigoCompra,
            string? codigoProveedor,
            bool    estado,
            string? usuarioRegistro,
            string? ipv4Registro,
            string? ipv6Registro)
        {
            var ahora = DateTime.UtcNow;
            return new Compra
            {
                IdCompra            = Guid.NewGuid(),
                CodigoCompra        = codigoCompra?.Trim(),
                CodigoProveedor     = codigoProveedor,
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

        public void Actualizar(
            string? codigoProveedor,
            bool    estado,
            string? usuarioModificacion,
            string? ipv4Modificacion,
            string? ipv6Modificacion)
        {
            CodigoProveedor     = codigoProveedor;
            Estado              = estado;
            FechaModificacion   = DateTime.UtcNow;
            UsuarioModificacion = usuarioModificacion;
            Ipv4Modificacion    = ipv4Modificacion;
            Ipv6Modificacion    = ipv6Modificacion;
        }
    }
}
