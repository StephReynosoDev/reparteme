using Microsoft.AspNetCore.Mvc;
using Reparteme.Dominio.Interfaces;

namespace Reparteme.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReporteController : ControllerBase
{
    private readonly IMovimientoRepositorio _movimientoRepo;
    private readonly IProductoRepositorio _productoRepo;

    public ReporteController(IMovimientoRepositorio movimientoRepo, IProductoRepositorio productoRepo)
    {
        _movimientoRepo = movimientoRepo;
        _productoRepo = productoRepo;
    }

    [HttpGet("consumo")]
    public async Task<ActionResult> ObtenerReporte()
    {
        var productos = await _productoRepo.ObtenerTodos();
        var movimientos = await _movimientoRepo.ObtenerTodos();

        var reporte = productos.Select(p => new
        {
            p.Id,
            p.Nombre,
            p.CantidadActual,
            Entradas = movimientos.Where(m => m.ProductoId == p.Id && m.Tipo == Dominio.Enums.TipoMovimiento.Entrada).Sum(m => m.Cantidad),
            Salidas = movimientos.Where(m => m.ProductoId == p.Id && m.Tipo == Dominio.Enums.TipoMovimiento.Salida).Sum(m => m.Cantidad)
        }).ToList();

        return Ok(reporte);
    }
}