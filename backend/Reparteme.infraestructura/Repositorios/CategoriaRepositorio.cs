using Microsoft.EntityFrameworkCore;
using Reparteme.Dominio.Entidades;
using Reparteme.Dominio.Interfaces;
using Reparteme.Infraestructura.Persistencia;

namespace Reparteme.Infraestructura.Repositorios;

public class CategoriaRepositorio : ICategoriaRepositorio
{
    private readonly AppDbContext _context;

    public CategoriaRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ObtenerTodas()
    {
        return await _context.Categorias.ToListAsync();

    }

    public async Task Crear(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task Actualizar(Categoria categoria)
    {
        _context.Categorias.Update(categoria);
        await _context.SaveChangesAsync();

    }

    public async Task Eliminar(Categoria categoria)
    {
        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
    }
}