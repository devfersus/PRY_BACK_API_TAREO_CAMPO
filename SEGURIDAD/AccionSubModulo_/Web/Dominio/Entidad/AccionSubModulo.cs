namespace SEGURIDAD.AccionSubModulo_.Web.Dominio.Entidad
{
    public class AccionSubModulo
    {
        public Guid Id          { get; private set; }
        public Guid SubModuloId { get; private set; }
        public Guid AccionId    { get; private set; }
        public bool Activo      { get; private set; }

        private AccionSubModulo() { }

        public static AccionSubModulo Registrar(Guid subModuloId, Guid accionId) =>
            new() { Id = Guid.NewGuid(), SubModuloId = subModuloId, AccionId = accionId, Activo = true };

        public void Actualizar(Guid subModuloId, Guid accionId)
        {
            SubModuloId = subModuloId;
            AccionId    = accionId;
        }

        public void EliminarLogico() => Activo = false;
    }
}
