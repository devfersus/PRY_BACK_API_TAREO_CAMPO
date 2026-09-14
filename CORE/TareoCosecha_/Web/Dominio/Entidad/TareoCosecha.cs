namespace CORE.TareoCosecha_.Web.Dominio.Entidad
{
    public class TareoCosecha
    {
        // PK — GUID generado por el móvil o por el servidor
        public Guid      IdTareoCosecha                            { get; private set; }

        // Campos de negocio
        public DateTime  FechaCosecha                             { get; private set; }
        public DateTime? FechaRegistroMovil                       { get; private set; }
        public decimal   Latitud                                  { get; private set; }
        public decimal   Longitud                                 { get; private set; }
        public int       TipoCosechaId                            { get; private set; }
        public int       TipoEnvaseId                             { get; private set; }
        public int       DniJabero                                { get; private set; }
        public int       NivelEnvaseId                            { get; private set; }
        public string?   FundoId                                  { get; private set; }
        public string?   VariedadId                               { get; private set; }
        public int       CalidadId                                { get; private set; }
        public int       DniCosechador                            { get; private set; }
        public string?   GrupoId                                  { get; private set; }
        public string?   SubgrupoId                               { get; private set; }
        public string?   TipoCosechadorId                         { get; private set; }
        public int       CantidadEnvases                          { get; private set; }
        public bool      Activo                                   { get; private set; }
        public bool      Sincronizado                             { get; private set; }

        // Auditoría estándar — registro
        public string?   UsuarioRegistro                          { get; private set; }
        public DateTime  FechaRegistro                            { get; private set; }
        public string?   Ipv4Registro                             { get; private set; }
        public string?   Ipv6Registro                             { get; private set; }
        public string?   DireccionMacRegistro                     { get; private set; }

        // Auditoría estándar — modificación
        public string?   UsuarioModificacion                      { get; private set; }
        public DateTime  FechaModificacion                        { get; private set; }
        public string?   Ipv4Modificacion                         { get; private set; }
        public string?   Ipv6Modificacion                         { get; private set; }
        public string?   DireccionMacModificacion                 { get; private set; }

        // Auditoría extendida móvil — registro
        public string?   LocalizacionGpsMovilRegistro             { get; private set; }
        public string?   TipoRedMovilRegistro                     { get; private set; }
        public string?   VersionAplicativoMovilRegistro           { get; private set; }
        public string?   InformacionDispositivoMovilRegistro      { get; private set; }

        // Auditoría extendida móvil — modificación
        public string?   LocalizacionGpsMovilModificacion         { get; private set; }
        public string?   TipoRedMovilModificacion                 { get; private set; }
        public string?   VersionAplicativoMovilModificacion       { get; private set; }
        public string?   InformacionDispositivoMovilModificacion  { get; private set; }

        private TareoCosecha() { }

        public static TareoCosecha Registrar(
            Guid?    envaseid,
            DateTime  fechaCosecha,
            DateTime? fechaRegistroMovil,
            decimal   latitud,
            decimal   longitud,
            int       tipoCosechaId,
            int       tipoEnvaseId,
            int       dniJabero,
            int       nivelEnvaseId,
            string?   fundoId,
            string?   variedadId,
            int       calidadId,
            int       dniCosechador,
            string?   grupoId,
            string?   subgrupoId,
            string?   tipoCosechadorId,
            int       cantidadEnvases,
            bool      activo,
            bool      sincronizado,
            string?   usuarioRegistro,
            string?   ipv4Registro,
            string?   ipv6Registro,
            string?   direccionMacRegistro,
            string?   localizacionGpsMovilRegistro,
            string?   tipoRedMovilRegistro,
            string?   versionAplicativoMovilRegistro,
            string?   informacionDispositivoMovilRegistro)
        {
            var ahora = DateTime.UtcNow;
            return new TareoCosecha
            {
                IdTareoCosecha                          = envaseid ?? Guid.NewGuid(),
                FechaCosecha                            = fechaCosecha,
                FechaRegistroMovil                      = fechaRegistroMovil,
                Latitud                                 = latitud,
                Longitud                                = longitud,
                TipoCosechaId                           = tipoCosechaId,
                TipoEnvaseId                            = tipoEnvaseId,
                DniJabero                               = dniJabero,
                NivelEnvaseId                           = nivelEnvaseId,
                FundoId                                 = fundoId?.Trim(),
                VariedadId                              = variedadId?.Trim(),
                CalidadId                               = calidadId,
                DniCosechador                           = dniCosechador,
                GrupoId                                 = grupoId?.Trim(),
                SubgrupoId                              = subgrupoId?.Trim(),
                TipoCosechadorId                        = tipoCosechadorId?.Trim(),
                CantidadEnvases                         = cantidadEnvases,
                Activo                                  = activo,
                Sincronizado                            = sincronizado,
                UsuarioRegistro                         = usuarioRegistro,
                FechaRegistro                           = ahora,
                Ipv4Registro                            = ipv4Registro,
                Ipv6Registro                            = ipv6Registro,
                DireccionMacRegistro                    = direccionMacRegistro,
                UsuarioModificacion                     = usuarioRegistro,
                FechaModificacion                       = ahora,
                Ipv4Modificacion                        = ipv4Registro,
                Ipv6Modificacion                        = ipv6Registro,
                DireccionMacModificacion                = null,
                LocalizacionGpsMovilRegistro            = localizacionGpsMovilRegistro,
                TipoRedMovilRegistro                    = tipoRedMovilRegistro,
                VersionAplicativoMovilRegistro          = versionAplicativoMovilRegistro,
                InformacionDispositivoMovilRegistro     = informacionDispositivoMovilRegistro,
                LocalizacionGpsMovilModificacion        = null,
                TipoRedMovilModificacion                = null,
                VersionAplicativoMovilModificacion      = null,
                InformacionDispositivoMovilModificacion = null
            };
        }
    }
}
