namespace SEGURIDAD.Accion_.Web.Dominio.Entidad
{
    public class Accion
    {
        public Guid   Id          { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;
        public bool   Activo      { get; private set; }

        private Accion() { }

        public static Accion Registrar(string descripcion) =>
            new() { Id = Guid.NewGuid(), Descripcion = descripcion.Trim(), Activo = true };

        public void Actualizar(string descripcion) =>
            Descripcion = descripcion.Trim();

        public void EliminarLogico() => Activo = false;
    }
}
