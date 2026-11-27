using Reparteme.Dominio.Entidades;

namespace Reparteme.Dominio.Interfaces;

public interface ICategoriaRepositorio
{
    Task<List<Categoria>> ObtenerTodas();
    Task<Categoria?> ObtenerPorId(Guid id);
    Task Crear(Categoria categoria);

    Task Actualizar(Categoria categoria);
    Task Eliminar(Categoria categoria);
}