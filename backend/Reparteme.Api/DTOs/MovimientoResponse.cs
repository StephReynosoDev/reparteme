namespace Reparteme.Api.DTOs;

public class MovimientoResponse
{
    public Guid Id { get; set; }
    public Guid ProductoId { get; set; }
    public string ProductoNombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public string Motivo { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; }
}