namespace MAESTRO.Almacen_.Web.Dominio.Exceptions
{
    public class AlmacenNoEncontradoException(string codigo)
        : Exception($"Almacén con código '{codigo}' no encontrado.")
    {
    }
}
