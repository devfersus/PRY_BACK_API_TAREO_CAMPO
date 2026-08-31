namespace MAESTRO.Producto_.Web.Dominio.Exceptions
{
    public class ProductoNoEncontradoException : Exception
    {
        public ProductoNoEncontradoException(string codigo)
            : base($"No se encontró un producto con el código '{codigo}'.") { }
    }
}
