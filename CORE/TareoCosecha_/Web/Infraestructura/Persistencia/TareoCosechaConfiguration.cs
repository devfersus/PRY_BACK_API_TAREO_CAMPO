using CORE.TareoCosecha_.Web.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CORE.TareoCosecha_.Web.Infraestructura.Persistencia
{
    public class TareoCosechaConfiguration : IEntityTypeConfiguration<TareoCosecha>
    {
        public void Configure(EntityTypeBuilder<TareoCosecha> builder)
        {
            builder.ToTable("tareo_cosecha");

            builder.HasKey(t => t.IdTareoCosecha);
            builder.Property(t => t.IdTareoCosecha)
                   .HasColumnName("tareo_cosecha_id");

            // Campos de negocio
            builder.Property(t => t.FechaCosecha)
                   .HasColumnName("fecha_cosecha")
                   .IsRequired();

            builder.Property(t => t.FechaRegistroMovil)
                   .HasColumnName("fecha_registro_movil");

            builder.Property(t => t.Latitud)
                   .HasColumnName("latitud")
                   .HasPrecision(10, 7);

            builder.Property(t => t.Longitud)
                   .HasColumnName("longitud")
                   .HasPrecision(10, 7);

            builder.Property(t => t.TipoCosechaId)
                   .HasColumnName("tipo_cosecha_id");

            builder.Property(t => t.TipoEnvaseId)
                   .HasColumnName("tipo_envase_id");

            builder.Property(t => t.DniJabero)
                   .HasColumnName("dni_jabero");

            builder.Property(t => t.NivelEnvaseId)
                   .HasColumnName("nivel_envase_id");

            builder.Property(t => t.FundoId)
                   .HasColumnName("fundo_id")
                   .HasMaxLength(10);

            builder.Property(t => t.VariedadId)
                   .HasColumnName("variedad_id")
                   .HasMaxLength(10);

            builder.Property(t => t.CalidadId)
                   .HasColumnName("calidad_id");

            builder.Property(t => t.DniCosechador)
                   .HasColumnName("dni_cosechador");

            builder.Property(t => t.GrupoId)
                   .HasColumnName("grupo_id")
                   .HasMaxLength(10);

            builder.Property(t => t.SubgrupoId)
                   .HasColumnName("subgrupo_id")
                   .HasMaxLength(10);

            builder.Property(t => t.TipoCosechadorId)
                   .HasColumnName("tipo_cosechador_id")
                   .HasMaxLength(10);

            builder.Property(t => t.CantidadEnvases)
                   .HasColumnName("cantidad_envases");

            builder.Property(t => t.Activo)
                   .HasColumnName("activo");

            builder.Property(t => t.Sincronizado)
                   .HasColumnName("sincronizado");

            // Auditoría estándar — registro
            builder.Property(t => t.UsuarioRegistro)
                   .HasColumnName("usuario_registro")
                   .HasMaxLength(20);

            builder.Property(t => t.FechaRegistro)
                   .HasColumnName("fecha_registro")
                   .IsRequired();

            builder.Property(t => t.Ipv4Registro)
                   .HasColumnName("ipv4_registro")
                   .HasMaxLength(25);

            builder.Property(t => t.Ipv6Registro)
                   .HasColumnName("ipv6_registro")
                   .HasMaxLength(25);

            builder.Property(t => t.DireccionMacRegistro)
                   .HasColumnName("direccion_mac_registro")
                   .HasMaxLength(50);

            // Auditoría estándar — modificación
            builder.Property(t => t.UsuarioModificacion)
                   .HasColumnName("usuario_modificacion")
                   .HasMaxLength(20);

            builder.Property(t => t.FechaModificacion)
                   .HasColumnName("fecha_modificacion")
                   .IsRequired();

            builder.Property(t => t.Ipv4Modificacion)
                   .HasColumnName("ipv4_modificacion")
                   .HasMaxLength(25);

            builder.Property(t => t.Ipv6Modificacion)
                   .HasColumnName("ipv6_modificacion")
                   .HasMaxLength(25);

            builder.Property(t => t.DireccionMacModificacion)
                   .HasColumnName("direccion_mac_modificacion")
                   .HasMaxLength(50);

            // Auditoría extendida móvil — registro
            builder.Property(t => t.LocalizacionGpsMovilRegistro)
                   .HasColumnName("localizacion_gps_movil_registro")
                   .HasMaxLength(100);

            builder.Property(t => t.TipoRedMovilRegistro)
                   .HasColumnName("tipo_red_movil_registro")
                   .HasMaxLength(50);

            builder.Property(t => t.VersionAplicativoMovilRegistro)
                   .HasColumnName("version_aplicativo_movil_registro")
                   .HasMaxLength(20);

            builder.Property(t => t.InformacionDispositivoMovilRegistro)
                   .HasColumnName("informacion_dispositivo_movil_registro")
                   .HasMaxLength(200);

            // Auditoría extendida móvil — modificación
            builder.Property(t => t.LocalizacionGpsMovilModificacion)
                   .HasColumnName("localizacion_gps_movil_modificacion")
                   .HasMaxLength(100);

            builder.Property(t => t.TipoRedMovilModificacion)
                   .HasColumnName("tipo_red_movil_modificacion")
                   .HasMaxLength(50);

            builder.Property(t => t.VersionAplicativoMovilModificacion)
                   .HasColumnName("version_aplicativo_movil_modificacion")
                   .HasMaxLength(20);

            builder.Property(t => t.InformacionDispositivoMovilModificacion)
                   .HasColumnName("informacion_dispositivo_movil_modificacion")
                   .HasMaxLength(200);
        }
    }
}
