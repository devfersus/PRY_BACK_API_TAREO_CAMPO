using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API_TAREO_CAMPO.Converters
{
    /// <summary>
    /// Acepta fechas en formato ISO 8601 (con 'T') y en el formato que envía
    /// la app móvil: "yyyy-MM-dd HH:mm:ss.ffffff" (con espacio).
    /// </summary>
    public sealed class FlexibleDateTimeConverter : JsonConverter<DateTime>
    {
        private static readonly string[] Formats =
        [
            "yyyy-MM-dd HH:mm:ss.ffffff",
            "yyyy-MM-dd HH:mm:ss.fffff",
            "yyyy-MM-dd HH:mm:ss.ffff",
            "yyyy-MM-dd HH:mm:ss.fff",
            "yyyy-MM-dd HH:mm:ss.ff",
            "yyyy-MM-dd HH:mm:ss.f",
            "yyyy-MM-dd HH:mm:ss",
            "yyyy-MM-dd"
        ];

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var raw = reader.GetString();

            if (raw is null)
                throw new JsonException("Se esperaba un valor de fecha/hora pero se recibió null.");

            // Intento estándar (ISO 8601 con 'T')
            if (DateTime.TryParse(raw, CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind, out var dt))
                return dt;

            // Formatos con espacio (app móvil)
            if (DateTime.TryParseExact(raw, Formats, CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dt))
                return dt;

            throw new JsonException($"No se pudo convertir '{raw}' a DateTime.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fff", CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Versión nullable que delega en <see cref="FlexibleDateTimeConverter"/>.
    /// </summary>
    public sealed class FlexibleNullableDateTimeConverter : JsonConverter<DateTime?>
    {
        private static readonly FlexibleDateTimeConverter Inner = new();

        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return null;

            return Inner.Read(ref reader, typeof(DateTime), options);
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value is null) writer.WriteNullValue();
            else Inner.Write(writer, value.Value, options);
        }
    }
}
