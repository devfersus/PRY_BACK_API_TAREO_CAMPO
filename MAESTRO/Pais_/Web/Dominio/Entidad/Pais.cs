namespace MAESTRO.Pais_.Web.Dominio.Entidad
{
    public class Pais
    {
        public Guid   Id          { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;
        public bool   Activo      { get; private set; }

        private Pais() { }

        public static Pais Registrar(string descripcion) =>
            new() { Id = Guid.NewGuid(), Descripcion = descripcion.Trim(), Activo = true };

        public void Actualizar(string descripcion) =>
            Descripcion = descripcion.Trim();

        public void EliminarLogico() => Activo = false;
    }
}
