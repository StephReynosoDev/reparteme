namespace Reparteme.Dominio.Entidades;

public abstract class BaseEntidad
{
    public Guid Id {get; set;}

    public DateTime FechaCreacion {get; set;}
}