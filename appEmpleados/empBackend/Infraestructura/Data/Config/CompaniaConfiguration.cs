using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class CompaniaConfiguration : IEntityTypeConfiguration<Compania>
    {
        public void Configure(EntityTypeBuilder<Compania> builder)
        {
          builder.Property(c => c.Id).IsRequired();
          builder.Property(c => c.NombreCompania).IsRequired().HasMaxLength(100);
          builder.Property(c => c.Direccion).IsRequired().HasMaxLength(150);
          builder.Property(c => c.Telefono).IsRequired().HasMaxLength(40);
          builder.Property(c =>c.Telefono2).IsRequired(false).HasMaxLength(40);
        }
    }
}