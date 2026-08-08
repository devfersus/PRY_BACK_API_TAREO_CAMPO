namespace SEGURIDAD.Login_.Web.Aplicacion.Ports
{
    public interface IJwtTokenGenerator
    {
        string GenerarToken(Guid id, string email);
    }
}
