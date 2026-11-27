using Microsoft.EntityFrameworkCore;
using Reparteme.Dominio.Entidades;
using Reparteme.Dominio.Interfaces;
using Reparteme.Infraestructura.Persistencia;

namespace Reparteme.Infraestructura.Repositorios;

public class ProductoRepositorio : IProductoRepositorio
{
    private readonly AppDbContext _context;

    public ProductoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Producto>> ObtenerTodos()
    {
        return await _context.Productos.Include(p => p.Categoria).ToListAsync();
    }

    public async Task<Producto?> ObtenerPorId(Guid id)
    {
        return await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Crear(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Producto producto)
    {
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar(Producto producto)
    {
        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();
    }
}