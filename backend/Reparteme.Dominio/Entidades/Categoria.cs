namespace Reparteme.Dominio.Entidades;

public class Categoria : BaseEntidad
{
    public string Nombre {get; set;} = string.Empty;
    public string Descripcion {get; set;} = string.Empty;
    public bool Activa {get; set;} = true;
}