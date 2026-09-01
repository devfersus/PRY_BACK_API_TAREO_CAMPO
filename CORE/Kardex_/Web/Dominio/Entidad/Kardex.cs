namespace CORE.Kardex_.Web.Dominio.Entidad
{
    public class Kardex
    {
        public Guid    IdKardex         { get; private set; }
        public string? TipoMovimiento   { get; private set; }
        public string? CodigoProducto   { get; private set; }
        public string? CodigoAlmacen    { get; private set; }
        public decimal Cantidad         { get; private set; }
        public decimal SaldoUnidades    { get; private set; }
        public string? ReferenciaTipo   { get; private set; }
        public string? ReferenciaCodig  { get; private set; }
        public DateTime FechaMovimiento { get; private set; }
        public string? UsuarioRegistro  { get; private set; }

        private Kardex() { }

        public static Kardex Registrar(
            string  tipoMovimiento,
            string? codigoProducto,
            string? codigoAlmacen,
            decimal cantidad,
            decimal saldoUnidades,
            string? referenciaTipo,
            string? referenciaCodig,
            string? usuarioRegistro)
        {
            return new Kardex
            {
                IdKardex        = Guid.NewGuid(),
                TipoMovimiento  = tipoMovimiento,
                CodigoProducto  = codigoProducto,
                CodigoAlmacen   = codigoAlmacen,
                Cantidad        = cantidad,
                SaldoUnidades   = saldoUnidades,
                ReferenciaTipo  = referenciaTipo,
                ReferenciaCodig = referenciaCodig,
                FechaMovimiento = DateTime.UtcNow,
                UsuarioRegistro = usuarioRegistro
            };
        }
    }
}
