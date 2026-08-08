namespace SEGURIDAD.Login_.Web.Aplicacion.DTOs
{
    public record SesionActivaDTO(
        Guid   UsuarioId,
        string Nombre,
        string Email,
        string ExpiraEn
    );
}
