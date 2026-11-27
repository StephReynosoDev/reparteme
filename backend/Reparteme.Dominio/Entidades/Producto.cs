namespace Reparteme.Dominio.Entidades;

public class Producto : BaseEntidad
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public int CantidadActual { get; set; }
    public Guid CategoriaId { get; set; }
    public Categoria Categoria { get; set; } = null!;
    public bool Activo { get; set; } = true;
}