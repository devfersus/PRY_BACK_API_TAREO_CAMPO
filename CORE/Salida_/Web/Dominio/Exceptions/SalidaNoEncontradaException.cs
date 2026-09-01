namespace CORE.Salida_.Web.Dominio.Exceptions
{
    public class SalidaNoEncontradaException(Guid id)
        : Exception($"Salida con id '{id}' no encontrada.");
}
