namespace SEGURIDAD.Proveedor_.Web.Dominio.Exceptions
{
    public class ProveedorNoEncontradoException : Exception
    {
        public ProveedorNoEncontradoException(string codigo)
            : base($"No se encontró un proveedor con el código '{codigo}'.") { }
    }
}
