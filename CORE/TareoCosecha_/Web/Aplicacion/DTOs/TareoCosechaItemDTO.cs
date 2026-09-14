namespace CORE.TareoCosecha_.Web.Aplicacion.DTOs
{
    public record TareoCosechaItemDTO(
        Guid?     EnvaseId,
        DateTime  FechaCosecha,
        DateTime? FechaRegistroMovil,
        decimal   Latitud,
        decimal   Longitud,
        int       TipoCosechaId,
        int       TipoEnvaseId,
        int       DniJabero,
        int       NivelEnvaseId,
        string?   FundoId,
        string?   VariedadId,
        int       CalidadId,
        int       DniCosechador,
        string?   GrupoId,
        string?   SubgrupoId,
        string?   TipoCosechadorId,
        int       CantidadEnvases,
        bool      Activo,
        bool      Sincronizado,
        string?   UsuarioRegistro,
        string?   Ipv4Registro,
        string?   Ipv6Registro,
        string?   DireccionMacRegistro,
        string?   LocalizacionGpsMovilRegistro,
        string?   TipoRedMovilRegistro,
        string?   VersionAplicativoMovilRegistro,
        string?   InformacionDispositivoMovilRegistro
    );
}
