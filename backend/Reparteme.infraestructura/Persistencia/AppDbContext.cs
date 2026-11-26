using Microsoft.EntityFrameworkCore;

namespace Reparteme.Infraestructura.Persistencia;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
        
            
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
        
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
}
    
