using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reparteme.Dominio.Entidades;

namespace Reparteme.Infraestructura.Persistencia;

public class CategoriaConfiguracion : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Descripcion).HasMaxLength(500);
    }
}