namespace CORE.Salida_.Web.Aplicacion.DTOs
{
    public class SalidaListadoDTO
    {
        public Guid    IdSalida     { get; set; }
        public string? CodigoSalida { get; set; }
        public string? Motivo       { get; set; }
        public bool    Estado       { get; set; }
    }
}
