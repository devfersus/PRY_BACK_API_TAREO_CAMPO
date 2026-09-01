namespace CORE.Ajuste_.Web.Dominio.Exceptions
{
    public class AjusteNoEncontradoException(Guid id)
        : Exception($"No se encontró el ajuste con id '{id}'.");
}
