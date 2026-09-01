namespace CORE.Kardex_.Web.Aplicacion.DTOs
{
    public record KardexDTO(
        Guid    IdKardex,
        string? TipoMovimiento,
        string? CodigoProducto,
        string? CodigoAlmacen,
        decimal Cantidad,
        decimal SaldoUnidades,
        string? ReferenciaTipo,
        string? ReferenciaCodig,
        DateTime FechaMovimiento,
        string? UsuarioRegistro);
}
