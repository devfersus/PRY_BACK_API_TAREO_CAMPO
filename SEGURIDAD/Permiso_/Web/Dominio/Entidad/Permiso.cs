namespace SEGURIDAD.Permiso_.Web.Dominio.Entidad
{
    public class Permiso
    {
        public Guid   Id          { get; private set; }
        public string Descripcion { get; private set; }
        public bool   Activo      { get; private set; }

        private Permiso() { }

        public static Permiso Registrar(string descripcion) =>
            new() { Id = Guid.NewGuid(), Descripcion = descripcion, Activo = true };

        public void Actualizar(string descripcion, bool activo)
        {
            Descripcion = descripcion;
            Activo      = activo;
        }

        public void EliminarLogico() => Activo = false;
    }
}
