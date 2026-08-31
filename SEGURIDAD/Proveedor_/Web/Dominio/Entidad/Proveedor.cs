namespace SEGURIDAD.Proveedor_.Web.Dominio.Entidad
{
    public class Proveedor
    {
        public Guid           IdProveedor       { get; private set; }
        public string?        Codigo            { get; private set; }
        public string?        Descripcion       { get; private set; }
        public string?        Comentario        { get; private set; }
        public string?        CodigoUsuario     { get; private set; }
        public bool           Estado            { get; private set; }
        public DateTimeOffset FechaRegistro       { get; private set; }
        public string?        UsuarioRegistro     { get; private set; }
        public string?        Ipv4Registro        { get; private set; }
        public string?        Ipv6Registro        { get; private set; }
        public DateTimeOffset FechaModificacion   { get; private set; }
        public string?        UsuarioModificacion { get; private set; }
        public string?        Ipv4Modificacion    { get; private set; }
        public string?        Ipv6Modificacion    { get; private set; }

        private Proveedor() { }

        public static Proveedor Registrar(
            string? codigo,
            string? descripcion,
            string? comentario,
            string? codigoUsuario,
            bool    estado,
            string? usuarioRegistro,
            string? ipv4Registro,
            string? ipv6Registro)
        {
            var ahora = DateTimeOffset.UtcNow;
            return new Proveedor
            {
                IdProveedor       = Guid.NewGuid(),
                Codigo            = codigo?.Trim(),
                Descripcion       = descripcion?.Trim(),
                Comentario        = comentario?.Trim(),
                CodigoUsuario     = codigoUsuario?.Trim(),
                Estado            = estado,
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
            string? descripcion,
            string? comentario,
            string? codigoUsuario,
            bool    estado,
            string? usuarioModificacion,
            string? ipv4Modificacion,
            string? ipv6Modificacion)
        {
            Descripcion         = descripcion?.Trim();
            Comentario          = comentario?.Trim();
            CodigoUsuario       = codigoUsuario?.Trim();
            Estado              = estado;
            FechaModificacion   = DateTimeOffset.UtcNow;
            UsuarioModificacion = usuarioModificacion;
            Ipv4Modificacion    = ipv4Modificacion;
            Ipv6Modificacion    = ipv6Modificacion;
        }
    }
}
