using Reparteme.Dominio.Entidades;

namespace Reparteme.Dominio.Interfaces;

public interface IMovimientoRepositorio
{
    Task<List<MovimientoInventario>> ObtenerTodos();
    Task Crear(MovimientoInventario movimiento);
}