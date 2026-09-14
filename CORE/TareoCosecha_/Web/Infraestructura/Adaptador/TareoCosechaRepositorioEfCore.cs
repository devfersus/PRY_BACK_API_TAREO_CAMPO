using CORE.Infraestructura;
using CORE.TareoCosecha_.Web.Dominio.Entidad;
using CORE.TareoCosecha_.Web.Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace CORE.TareoCosecha_.Web.Infraestructura.Adaptador
{
    public class TareoCosechaRepositorioEfCore(CoreDBContext ctx) : ITareoCosechaRepository
    {
        public async Task AgregarMasivoAsync(List<TareoCosecha> registros, CancellationToken ct = default)
        {
            var conn = (NpgsqlConnection)ctx.Database.GetDbConnection();
            if (conn.State != ConnectionState.Open)
                await conn.OpenAsync(ct);

            using var writer = await conn.BeginBinaryImportAsync(
                """
                COPY tareo_cosecha (
                    tareo_cosecha_id,
                    fecha_cosecha,
                    fecha_registro_movil,
                    latitud,
                    longitud,
                    tipo_cosecha_id,
                    tipo_envase_id,
                    dni_jabero,
                    nivel_envase_id,
                    fundo_id,
                    variedad_id,
                    calidad_id,
                    dni_cosechador,
                    grupo_id,
                    subgrupo_id,
                    tipo_cosechador_id,
                    cantidad_envases,
                    activo,
                    sincronizado,
                    usuario_registro,
                    fecha_registro,
                    ipv4_registro,
                    ipv6_registro,
                    direccion_mac_registro,
                    usuario_modificacion,
                    fecha_modificacion,
                    ipv4_modificacion,
                    ipv6_modificacion,
                    direccion_mac_modificacion,
                    localizacion_gps_movil_registro,
                    tipo_red_movil_registro,
                    version_aplicativo_movil_registro,
                    informacion_dispositivo_movil_registro,
                    localizacion_gps_movil_modificacion,
                    tipo_red_movil_modificacion,
                    version_aplicativo_movil_modificacion,
                    informacion_dispositivo_movil_modificacion
                ) FROM STDIN (FORMAT BINARY)
                """, ct);

            foreach (var r in registros)
            {
                await writer.StartRowAsync(ct);

                await writer.WriteAsync(r.IdTareoCosecha, NpgsqlDbType.Uuid, ct);
                await writer.WriteAsync(r.FechaCosecha,   NpgsqlDbType.Timestamp, ct);
                await EscribirNullableDateTimeAsync(writer, r.FechaRegistroMovil, ct);
                await writer.WriteAsync(r.Latitud,  NpgsqlDbType.Numeric, ct);
                await writer.WriteAsync(r.Longitud, NpgsqlDbType.Numeric, ct);
                await writer.WriteAsync(r.TipoCosechaId,  NpgsqlDbType.Integer, ct);
                await writer.WriteAsync(r.TipoEnvaseId,   NpgsqlDbType.Integer, ct);
                await writer.WriteAsync(r.DniJabero,      NpgsqlDbType.Integer, ct);
                await writer.WriteAsync(r.NivelEnvaseId,  NpgsqlDbType.Integer, ct);
                await EscribirNullableStringAsync(writer, r.FundoId, ct);
                await EscribirNullableStringAsync(writer, r.VariedadId, ct);
                await writer.WriteAsync(r.CalidadId,      NpgsqlDbType.Integer, ct);
                await writer.WriteAsync(r.DniCosechador,  NpgsqlDbType.Integer, ct);
                await EscribirNullableStringAsync(writer, r.GrupoId, ct);
                await EscribirNullableStringAsync(writer, r.SubgrupoId, ct);
                await EscribirNullableStringAsync(writer, r.TipoCosechadorId, ct);
                await writer.WriteAsync(r.CantidadEnvases, NpgsqlDbType.Integer, ct);
                await writer.WriteAsync(r.Activo,       NpgsqlDbType.Boolean, ct);
                await writer.WriteAsync(r.Sincronizado, NpgsqlDbType.Boolean, ct);

                await EscribirNullableStringAsync(writer, r.UsuarioRegistro, ct);
                await writer.WriteAsync(r.FechaRegistro, NpgsqlDbType.Timestamp, ct);
                await EscribirNullableStringAsync(writer, r.Ipv4Registro, ct);
                await EscribirNullableStringAsync(writer, r.Ipv6Registro, ct);
                await EscribirNullableStringAsync(writer, r.DireccionMacRegistro, ct);

                await EscribirNullableStringAsync(writer, r.UsuarioModificacion, ct);
                await writer.WriteAsync(r.FechaModificacion, NpgsqlDbType.Timestamp, ct);
                await EscribirNullableStringAsync(writer, r.Ipv4Modificacion, ct);
                await EscribirNullableStringAsync(writer, r.Ipv6Modificacion, ct);
                await EscribirNullableStringAsync(writer, r.DireccionMacModificacion, ct);

                await EscribirNullableStringAsync(writer, r.LocalizacionGpsMovilRegistro, ct);
                await EscribirNullableStringAsync(writer, r.TipoRedMovilRegistro, ct);
                await EscribirNullableStringAsync(writer, r.VersionAplicativoMovilRegistro, ct);
                await EscribirNullableStringAsync(writer, r.InformacionDispositivoMovilRegistro, ct);

                await EscribirNullableStringAsync(writer, r.LocalizacionGpsMovilModificacion, ct);
                await EscribirNullableStringAsync(writer, r.TipoRedMovilModificacion, ct);
                await EscribirNullableStringAsync(writer, r.VersionAplicativoMovilModificacion, ct);
                await EscribirNullableStringAsync(writer, r.InformacionDispositivoMovilModificacion, ct);
            }

            await writer.CompleteAsync(ct);
        }

        private static async Task EscribirNullableStringAsync(
            NpgsqlBinaryImporter writer, string? valor, CancellationToken ct)
        {
            if (valor is null)
                await writer.WriteNullAsync(ct);
            else
                await writer.WriteAsync(valor, NpgsqlDbType.Varchar, ct);
        }

        private static async Task EscribirNullableDateTimeAsync(
            NpgsqlBinaryImporter writer, DateTime? valor, CancellationToken ct)
        {
            if (valor is null)
                await writer.WriteNullAsync(ct);
            else
                await writer.WriteAsync(valor.Value, NpgsqlDbType.Timestamp, ct);
        }
    }
}
