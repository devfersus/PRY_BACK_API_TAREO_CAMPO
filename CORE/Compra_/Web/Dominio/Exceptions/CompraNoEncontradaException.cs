namespace CORE.Compra_.Web.Dominio.Exceptions
{
    public class CompraNoEncontradaException : Exception
    {
        public CompraNoEncontradaException(Guid id)
            : base($"No se encontró una compra con el id '{id}'.") { }
    }
}
