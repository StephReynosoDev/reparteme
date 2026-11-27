using Microsoft.AspNetCore.Mvc;
using Reparteme.Api.DTOs;
using Reparteme.Dominio.Entidades;
using Reparteme.Dominio.Interfaces;

namespace Reparteme.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepositorio _repositorio;

    public ProductosController(IProductoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductoResponse>>> ObtenerTodos()
    {
        var productos = await _repositorio.ObtenerTodos();
        var response = productos.Select(p => new ProductoResponse
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Foto = p.Foto,
            CantidadActual = p.CantidadActual,
            CategoriaId = p.CategoriaId,
            CategoriaNombre = p.Categoria.Nombre,
            Activo = p.Activo,
            FechaCreacion = p.FechaCreacion
        }).ToList();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoResponse>> ObtenerPorId(Guid id)
    {
        var p = await _repositorio.ObtenerPorId(id);
        if (p == null) return NotFound();
        return Ok(new ProductoResponse
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Foto = p.Foto,
            CantidadActual = p.CantidadActual,
            CategoriaId = p.CategoriaId,
            CategoriaNombre = p.Categoria.Nombre,
            Activo = p.Activo,
            FechaCreacion = p.FechaCreacion
        });
    }

    [HttpPost]
    public async Task<ActionResult<ProductoResponse>> Crear(CrearProductoRequest request)
    {
        var producto = new Producto
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion,
            Foto = request.Foto,
            CantidadActual = request.CantidadActual,
            CategoriaId = request.CategoriaId
        };
        await _repositorio.Crear(producto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, new ProductoResponse
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Descripcion = producto.Descripcion,
            Foto = producto.Foto,
            CantidadActual = producto.CantidadActual,
            CategoriaId = producto.CategoriaId,
            Activo = producto.Activo,
            FechaCreacion = producto.FechaCreacion
        });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(Guid id, ActualizarProductoRequest request)
    {
        var producto = await _repositorio.ObtenerPorId(id);
        if (producto == null) return NotFound();
        producto.Nombre = request.Nombre;
        producto.Descripcion = request.Descripcion;
        producto.Foto = request.Foto;
        producto.CantidadActual = request.CantidadActual;
        producto.CategoriaId = request.CategoriaId;
        producto.Activo = request.Activo;
        await _repositorio.Actualizar(producto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Eliminar(Guid id)
    {
        var producto = await _repositorio.ObtenerPorId(id);
        if (producto == null) return NotFound();
        await _repositorio.Eliminar(producto);
        return NoContent();
    }
}