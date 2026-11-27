using Reparteme.Dominio.Enums;

namespace Reparteme.Api.DTOs;

public class CrearMovimientoRequest
{
    public Guid ProductoId { get; set; }
    public int Cantidad { get; set; }
    public TipoMovimiento Tipo { get; set; }
    public string Motivo { get; set; } = string.Empty;
}