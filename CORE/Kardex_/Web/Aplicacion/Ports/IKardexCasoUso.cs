using CORE.Kardex_.Web.Aplicacion.DTOs;

namespace CORE.Kardex_.Web.Aplicacion.Ports
{
    public interface IKardexCasoUso
    {
        Task<List<KardexDTO>> ListarAsync(CancellationToken ct = default);
        Task<List<KardexDTO>> ListarPorProductoAlmacenAsync(string codigoProducto, string? codigoAlmacen, CancellationToken ct = default);
        Task                  RegistrarMovimientoAsync(
                                  string  tipoMovimiento,
                                  string  codigoProducto,
                                  string? codigoAlmacen,
                                  decimal cantidad,
                                  decimal saldoUnidades,
                                  string? referenciaTipo,
                                  string? referenciaCodig,
                                  string? usuarioRegistro,
                                  CancellationToken ct = default);
    }
}
