using Microsoft.EntityFrameworkCore;
using Reparteme.Dominio.Entidades;
using Reparteme.Dominio.Interfaces;
using Reparteme.Infraestructura.Persistencia;

namespace Reparteme.Infraestructura.Repositorios;

public class MovimientoRepositorio : IMovimientoRepositorio
{
    private readonly AppDbContext _context;

    public MovimientoRepositorio(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MovimientoInventario>> ObtenerTodos()
    {
        return await _context.Movimientos.Include(m => m.Producto).ToListAsync();
    }

    public async Task Crear(MovimientoInventario movimiento)
    {
        _context.Movimientos.Add(movimiento);
        await _context.SaveChangesAsync();
    }
}