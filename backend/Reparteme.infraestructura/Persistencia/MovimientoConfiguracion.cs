using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reparteme.Dominio.Entidades;

namespace Reparteme.Infraestructura.Persistencia;

public class MovimientoConfiguracion : IEntityTypeConfiguration<MovimientoInventario>
{
    public void Configure(EntityTypeBuilder<MovimientoInventario> builder)
    {
        builder.ToTable("Movimientos");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Motivo).HasMaxLength(500);
        builder.HasOne(m => m.Producto)
            .WithMany()
            .HasForeignKey(m => m.ProductoId);
    }
}