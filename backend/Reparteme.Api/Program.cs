using Microsoft.EntityFrameworkCore;
using Reparteme.Infraestructura.Persistencia;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
   builder.Configuration.GetConnectionString("DefaultConnection")) );

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();