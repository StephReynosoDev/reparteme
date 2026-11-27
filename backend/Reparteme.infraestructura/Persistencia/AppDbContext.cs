using Microsoft.EntityFrameworkCore;
using Reparteme.Dominio.Entidades;



namespace Reparteme.Infraestructura.Persistencia;


public class AppDbContext : DbContext
{

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
        
            
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
        
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
}
    
