using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reparteme.Dominio.Entidades;

namespace Reparteme.Infraestructura.Persistencia;

public class CategoriaConfiduracion : IEntityTypeConfiguration<Categoria>
{
    public void Conifigure(EntityTypeBuilder<Categoria> builder)
    {
        buider.Totable("Categorias");
        buider.HasKey(c => c.Id);
        buider.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
        buider.Property(c => c.Descripcion).HasMaxLength(500);
    }
}