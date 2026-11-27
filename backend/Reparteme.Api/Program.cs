using Microsoft.EntityFrameworkCore;
using Reparteme.Infraestructura.Persistencia;
using Reparteme.Dominio.Interfaces;
using Reparteme.Infraestructura.Repositorios;
using Reparteme.Infraestructura.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
   
   builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite(connectionString));

builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddScoped<IMovimientoRepositorio, MovimientoRepositorio>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await SeedData.Inicializar(context);
}


app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();