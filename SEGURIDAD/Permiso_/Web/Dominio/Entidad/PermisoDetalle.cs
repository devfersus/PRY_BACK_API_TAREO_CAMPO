using SEGURIDAD.Accion_.Web.Dominio.Entidad;
using SEGURIDAD.Modulo_.Web.Dominio.Entidad;
using SEGURIDAD.SubModulo_.Web.Dominio.Entidad;

namespace SEGURIDAD.Permiso_.Web.Dominio.Entidad
{
    public class PermisoDetalle
    {
        public Guid       Id          { get; private set; }
        public Guid       PermisoId   { get; private set; }
        public Guid       ModuloId    { get; private set; }
        public Guid       SubModuloId { get; private set; }
        public Guid       AccionId    { get; private set; }
        public bool       Activo      { get; private set; }
        public Modulo?    Modulo      { get; private set; }
        public SubModulo? SubModulo   { get; private set; }
        public Accion?    Accion      { get; private set; }

        private PermisoDetalle() { }

        public static PermisoDetalle Registrar(Guid permisoId, Guid moduloId, Guid subModuloId, Guid accionId) =>
            new()
            {
                Id          = Guid.NewGuid(),
                PermisoId   = permisoId,
                ModuloId    = moduloId,
                SubModuloId = subModuloId,
                AccionId    = accionId,
                Activo      = true
            };

        public void Actualizar(Guid moduloId, Guid subModuloId, Guid accionId, bool activo)
        {
            ModuloId    = moduloId;
            SubModuloId = subModuloId;
            AccionId    = accionId;
            Activo      = activo;
        }

        public void EliminarLogico() => Activo = false;
    }
}
