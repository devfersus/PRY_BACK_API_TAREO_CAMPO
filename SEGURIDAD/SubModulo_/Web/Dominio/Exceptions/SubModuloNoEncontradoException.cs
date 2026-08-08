namespace SEGURIDAD.SubModulo_.Web.Dominio.Exceptions
{
    public class SubModuloNoEncontradoException : Exception
    {
        public SubModuloNoEncontradoException(Guid id)
            : base($"No se encontró un submódulo con el id '{id}'.") { }
    }
}
