using Exam.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.SqlServer.Configurations;
public class SuscripcionConfig : IEntityTypeConfiguration<Suscripcion>
{
    public void Configure(EntityTypeBuilder<Suscripcion> builder)
    {
        builder.ToTable("Suscripcion").HasKey(p => p.IdAsociacion).HasName("IdAsociacion");
        builder.Property(p => p.IdSuscriptor).HasColumnType("int");
        builder.Property(p => p.FechaAlta).HasColumnType("datetime");
        builder.Property(p => p.FechaFin).HasColumnType("datetime");
        builder.Property(p => p.MotivoFin).HasColumnType("varchar(500)").HasMaxLength(500);
    }
}
