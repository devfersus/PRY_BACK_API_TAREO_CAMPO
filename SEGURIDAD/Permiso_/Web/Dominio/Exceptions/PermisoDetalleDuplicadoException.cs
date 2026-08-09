namespace SEGURIDAD.Permiso_.Web.Dominio.Exceptions
{
    public class PermisoDetalleDuplicadoException : Exception
    {
        public PermisoDetalleDuplicadoException()
            : base("Ya existe este registro.") { }
    }
}
