using Microsoft.AspNetCore.Mvc;
using Reparteme.Api.DTOs;
using Reparteme.Dominio.Entidades;
using Reparteme.Dominio.Interfaces;

namespace Reparteme.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimientosController : ControllerBase
{
    private readonly IMovimientoRepositorio _repositorio;
    private readonly IProductoRepositorio _productoRepo;

    public MovimientosController(IMovimientoRepositorio repositorio, IProductoRepositorio productoRepo)
    {
        _repositorio = repositorio;
        _productoRepo = productoRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<MovimientoResponse>>> ObtenerTodos()
    {
        var movimientos = await _repositorio.ObtenerTodos();
        var response = movimientos.Select(m => new MovimientoResponse
        {
            Id = m.Id,
            ProductoId = m.ProductoId,
            ProductoNombre = m.Producto.Nombre,
            Cantidad = m.Cantidad,
            Tipo = m.Tipo.ToString(),
            Motivo = m.Motivo,
            FechaCreacion = m.FechaCreacion
        }).ToList();
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Crear(CrearMovimientoRequest request)
    {
        var producto = await _productoRepo.ObtenerPorId(request.ProductoId);
        if (producto == null) return NotFound("Producto no encontrado");

        var movimiento = new MovimientoInventario
        {
            ProductoId = request.ProductoId,
            Cantidad = request.Cantidad,
            Tipo = request.Tipo,
            Motivo = request.Motivo
        };

        switch (request.Tipo)
        {
            case Dominio.Enums.TipoMovimiento.Entrada:
                producto.CantidadActual += request.Cantidad;
                break;
            case Dominio.Enums.TipoMovimiento.Salida:
                producto.CantidadActual -= request.Cantidad;
                break;
        }

        await _productoRepo.Actualizar(producto);
        await _repositorio.Crear(movimiento);
        return Ok();
    }
}