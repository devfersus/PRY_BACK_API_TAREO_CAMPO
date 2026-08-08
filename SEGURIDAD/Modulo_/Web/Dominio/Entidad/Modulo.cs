namespace SEGURIDAD.Modulo_.Web.Dominio.Entidad
{
    public class Modulo
    {
        public Guid   Id          { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;
        public bool   Activo      { get; private set; }

        private Modulo() { }

        public static Modulo Registrar(string descripcion) =>
            new() { Id = Guid.NewGuid(), Descripcion = descripcion.Trim(), Activo = true };

        public void Actualizar(string descripcion) =>
            Descripcion = descripcion.Trim();

        public void EliminarLogico() => Activo = false;
    }
}
