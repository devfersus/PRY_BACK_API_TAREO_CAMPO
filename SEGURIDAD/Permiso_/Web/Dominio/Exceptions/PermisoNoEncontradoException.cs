namespace SEGURIDAD.Permiso_.Web.Dominio.Exceptions
{
    public class PermisoNoEncontradoException : Exception
    {
        public PermisoNoEncontradoException(Guid id)
            : base($"No se encontró un permiso con el id '{id}'.") { }
    }
}
