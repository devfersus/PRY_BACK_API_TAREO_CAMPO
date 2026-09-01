namespace MAESTRO.UnidadMedida_.Web.Dominio.Exceptions
{
    public class UnidadMedidaNoEncontradaException(string codigo)
        : Exception($"Unidad de medida con código '{codigo}' no encontrada.")
    {
    }
}
