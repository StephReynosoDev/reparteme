using Reparteme.Dominio.Enums;


namespace Reparteme.Dominio.Entidades;

public class MovimientoInventario : BaseEntidad
{
    public Guid ProductoId { get; set; }
    public Producto Producto { get; set; } = null!;
    public int Cantidad { get; set; }
    public TipoMovimiento Tipo { get; set; }
    public string Motivo { get; set; } = string.Empty;
}