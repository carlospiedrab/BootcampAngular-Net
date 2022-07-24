using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
           builder.Property(e => e.Id).IsRequired();
           builder.Property(e => e.Apellidos).IsRequired().HasMaxLength(100);
           builder.Property(e => e.Nombres).IsRequired().HasMaxLength(100);
           builder.Property(e => e.Cargo).IsRequired().HasMaxLength(100);
           builder.Property(e => e.CompaniaId).IsRequired();

           // TODO Relaciones
           builder.HasOne(e => e.Compania).WithMany()
                  .HasForeignKey(e => e.CompaniaId);
           

        }
    }
}