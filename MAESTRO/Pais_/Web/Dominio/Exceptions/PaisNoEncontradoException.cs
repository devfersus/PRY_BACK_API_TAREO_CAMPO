namespace MAESTRO.Pais_.Web.Dominio.Exceptions
{
    public class PaisNoEncontradoException : Exception
    {
        public PaisNoEncontradoException(Guid id)
            : base($"No se encontró un país con el id '{id}'.") { }
    }
}
