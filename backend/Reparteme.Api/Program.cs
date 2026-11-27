using Microsoft.EntityFrameworkCore;
using Reparteme.Infraestructura.Persistencia;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DATABASE_URL");
   
   builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlite(connectionString));

app.UseStaticFiles();
app.MapControllers();

app.Run();