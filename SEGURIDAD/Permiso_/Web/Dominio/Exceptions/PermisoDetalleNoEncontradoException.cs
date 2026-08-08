namespace SEGURIDAD.Permiso_.Web.Dominio.Exceptions
{
    public class PermisoDetalleNoEncontradoException : Exception
    {
        public PermisoDetalleNoEncontradoException(Guid id)
            : base($"No se encontró un permiso detalle con el id '{id}'.") { }
    }
}
