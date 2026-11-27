using Microsoft.AspNetCore.Mvc;
using Reparteme.Api.DTOs;
using Reparteme.Dominio.Entidades;
using Reparteme.Dominio.Interfaces;

namespace Reparteme.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaRepositorio _repositorio;

    public CategoriasController(ICategoriaRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoriaResponse>>> ObtenerTodas()
    {
        var categorias = await _repositorio.ObtenerTodas();
        var response = categorias.Select(c => new CategoriaResponse
        {
            Id = c.Id,
            Nombre = c.Nombre,
            Descripcion = c.Descripcion,
            Activa = c.Activa,
            FechaCreacion = c.FechaCreacion
        
        }).ToList();
        return Ok(response);
    }



    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaResponse>> ObtenerPorId(Guid id)
    {
        var categoria = await _repositorio.ObtenerPorId(id);
        if (categoria == null) return NotFound();
        return Ok(new CategoriaResponse
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion,
            Activa = categoria.Activa,
            FechaCreacion = categoria.FechaCreacion
        });
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaResponse>> Crear(CrearCategoriaRequest request)
    {
        var categoria = new Categoria
        {
            Nombre = request.Nombre,
            Descripcion = request.Descripcion
        };

        await _repositorio.Crear(categoria);
        var response = new CategoriaResponse
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion,
            Activa = categoria.Activa,
            FechaCreacion = categoria.FechaCreacion
                    };
        return CreatedAtAction(nameof(ObtenerPorId), new { id = categoria.Id }, response);
    }

     [HttpPut("{id}")]
    public async Task<ActionResult> Actualizar(Guid id, ActualizarCategoriaRequest request)
    {
        var categoria = await _repositorio.ObtenerPorId(id);
        if (categoria == null) return NotFound();
        categoria.Nombre = request.Nombre;
        categoria.Descripcion = request.Descripcion;
        categoria.Activa = request.Activa;
        await _repositorio.Actualizar(categoria);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Eliminar(Guid id)
    {
        var categoria = await _repositorio.ObtenerPorId(id);
        if (categoria == null) return NotFound();
        await _repositorio.Eliminar(categoria);
        return NoContent();
    }
}



