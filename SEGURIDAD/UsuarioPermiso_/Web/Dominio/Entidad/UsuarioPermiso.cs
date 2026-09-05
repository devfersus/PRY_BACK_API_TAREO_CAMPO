namespace SEGURIDAD.UsuarioPermiso_.Web.Dominio.Entidad
{
    public class UsuarioPermiso
    {
        public Guid Id        { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid PermisoId { get; private set; }
        public bool Activo    { get; private set; }

        private UsuarioPermiso() { }

        public static UsuarioPermiso Asignar(Guid usuarioId, Guid permisoId) =>
            new() { Id = Guid.NewGuid(), UsuarioId = usuarioId, PermisoId = permisoId, Activo = true };

        public void Desactivar() => Activo = false;
        public void Activar()    => Activo = true;
    }
}
