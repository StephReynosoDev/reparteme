namespace Reparteme.Api.DTOs;

public class CategoriaResponse
{
    public Guid Id {get; set;}
    public string Nombre {get; set;} = string.Empty;
    public string Descripcion {get; set;} = string.Empty;

    public bool Activa {get; set;}

    public DateTime FechaCreacion {get; set;}
    
}