namespace SEGURIDAD.UsuarioPermiso_.Web.Aplicacion.Ports
{
    public interface IPermisoUsuarioConsultaServicio
    {
        /// <summary>
        /// Retorna las claves de permiso normalizadas del usuario desde la BD.
        /// Formato: "MODULO|SUBMODULO|ACCION" en mayúsculas.
        /// </summary>
        Task<List<string>> ObtenerClavesPermisoAsync(Guid usuarioId, CancellationToken ct = default);
    }
}
