using Reparteme.Dominio.Entidades;

namespace Reparteme.Dominio.Interfaces;

public interface IProductoRepositorio
{
    Task<List<Producto>> ObtenerTodos();
    Task<Producto?> ObtenerPorId(Guid id);
    Task Crear(Producto producto);
    Task Actualizar(Producto producto);
    Task Eliminar(Producto producto);
}