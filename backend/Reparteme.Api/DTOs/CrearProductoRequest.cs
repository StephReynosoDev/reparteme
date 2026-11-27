namespace Reparteme.Api.DTOs;

public class CrearProductoRequest
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public int CantidadActual { get; set; }
    public Guid CategoriaId { get; set; }
}