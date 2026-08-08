namespace SEGURIDAD.Modulo_.Web.Dominio.Exceptions
{
    public class ModuloNoEncontradoException : Exception
    {
        public ModuloNoEncontradoException(Guid id)
            : base($"No se encontró un módulo con el id '{id}'.") { }
    }
}
