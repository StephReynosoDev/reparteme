using Microsoft.EntityFrameworkCore;
using Reparteme.Infraestructura.Persistencia;
using Reparteme.Dominio.Interfaces;
using Reparteme.Infraestructura.Repositorios;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
   
   builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite(connectionString));

builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddScoped<IProductoRepositorio, ProductoRepositorio>();

var app = builder.Build();


app.UseStaticFiles();
app.MapControllers();

app.Run();