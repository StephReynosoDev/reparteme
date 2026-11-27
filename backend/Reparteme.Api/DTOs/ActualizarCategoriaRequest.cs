namespace Reparteme.Api.DTOs;

public class ActualizarCategoriaRequest
{
    public string Nombre {get; set;} = string.Empty;
    public string Descripcion {get; set;} = string.Empty;

    public bool Activa {get; set;}

    
}
