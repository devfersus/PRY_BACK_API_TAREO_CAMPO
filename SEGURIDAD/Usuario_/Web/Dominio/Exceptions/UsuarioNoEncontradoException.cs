namespace SEGURIDAD.Usuario_.Web.Dominio.Exceptions
{
    public class UsuarioNoEncontradoException : Exception
    {
        public UsuarioNoEncontradoException(Guid id)
            : base($"No se encontró un usuario con el id '{id}'.") { }
    }
}
