namespace SEGURIDAD.LogAuditoria_.Web.Dominio.Entidad;

public class LogAuditoria
{
    public Guid    IdLogAuditoria  { get; private set; }
    public Guid    UsuarioRegistro { get; private set; }
    public string  NombreTabla     { get; private set; } = string.Empty;
    public string  Accion          { get; private set; } = string.Empty;
    public DateTime FechaRegistro  { get; private set; }
    public string? ValorAnterior   { get; private set; }
    public string? ValorNuevo      { get; private set; }

    private LogAuditoria() { }

    public static LogAuditoria Registrar(
        Guid    usuarioRegistro,
        string  nombreTabla,
        string  accion,
        string? valorAnterior,
        string? valorNuevo) =>
        new()
        {
            IdLogAuditoria  = Guid.NewGuid(),
            UsuarioRegistro = usuarioRegistro,
            NombreTabla     = nombreTabla,
            Accion          = accion,
            FechaRegistro   = DateTime.UtcNow,
            ValorAnterior   = valorAnterior,
            ValorNuevo      = valorNuevo
        };
}
