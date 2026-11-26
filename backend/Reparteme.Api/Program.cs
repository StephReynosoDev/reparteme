using Microsoft.EntityFrameworkCore;
using Reparteme.Infraestructura.Persistencia;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") 
   ??builder.Configuration.GetConnectionString("DefaultConnection");
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();