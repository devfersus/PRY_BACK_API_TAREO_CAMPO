namespace SEGURIDAD.AccionSubModulo_.Web.Dominio.Exceptions
{
    public class AccionSubModuloNoEncontradaException : Exception
    {
        public AccionSubModuloNoEncontradaException(Guid id)
            : base($"No se encontró una acción-submódulo con el id '{id}'.") { }
    }
}
