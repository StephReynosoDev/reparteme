using Microsoft.EntityFrameworkCore;
using Reparteme.Dominio.Entidades;
using Reparteme.Infraestructura.Persistencia;

namespace Reparteme.Infraestructura.Seed;

public static class SeedData
{
    public static async Task Inicializar(AppDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (await context.Categorias.AnyAsync()) return;

        var alimentos = new Categoria { Nombre = "Alimentos", Descripcion = "Productos alimenticios", Activa = true };
        var bebidas = new Categoria { Nombre = "Bebidas", Descripcion = "Bebidas y liquidos", Activa = true };
        var limpieza = new Categoria { Nombre = "Limpieza", Descripcion = "Productos de limpieza", Activa = true };

        context.Categorias.AddRange(alimentos, bebidas, limpieza);
        await context.SaveChangesAsync();

        context.Productos.AddRange(
            new Producto { Nombre = "Arroz", Descripcion = "Arroz blanco 5lb", CantidadActual = 50, CategoriaId = alimentos.Id, Activo = true },
            new Producto { Nombre = "Habichuela", Descripcion = "Habichuela roja 3lb", CantidadActual = 30, CategoriaId = alimentos.Id, Activo = true },
            new Producto { Nombre = "Agua", Descripcion = "Botellon de agua 5gal", CantidadActual = 20, CategoriaId = bebidas.Id, Activo = true },
            new Producto { Nombre = "Jugo", Descripcion = "Jugo de naranja 1lt", CantidadActual = 25, CategoriaId = bebidas.Id, Activo = true },
            new Producto { Nombre = "Cloro", Descripcion = "Cloro desinfectante 1gal", CantidadActual = 15, CategoriaId = limpieza.Id, Activo = true }
        );
        await context.SaveChangesAsync();
    }
}