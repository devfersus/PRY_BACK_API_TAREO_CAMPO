namespace MAESTRO.Categoria_.Web.Dominio.Exceptions
{
    public class CategoriaNoEncontradaException : Exception
    {
        public CategoriaNoEncontradaException(string codigo)
            : base($"No se encontró una categoría con el código '{codigo}'.") { }
    }
}
