namespace SEGURIDAD.Accion_.Web.Dominio.Exceptions
{
    public class AccionNoEncontradaException : Exception
    {
        public AccionNoEncontradaException(Guid id)
            : base($"No se encontró una acción con el id '{id}'.") { }
    }
}
