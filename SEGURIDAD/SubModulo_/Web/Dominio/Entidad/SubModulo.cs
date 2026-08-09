namespace SEGURIDAD.SubModulo_.Web.Dominio.Entidad
{
    public class SubModulo
    {
        public Guid   Id          { get; private set; }
        public string Descripcion { get; private set; } = string.Empty;
        public bool   Activo      { get; private set; }

        private SubModulo() { }

        public static SubModulo Registrar(string descripcion) =>
            new() { Id = Guid.NewGuid(), Descripcion = descripcion.Trim(), Activo = true };

        public void Actualizar(string descripcion, bool activo)
        {
            Descripcion = descripcion.Trim();
            Activo      = activo;
        }

        public void EliminarLogico() => Activo = false;
    }
}
