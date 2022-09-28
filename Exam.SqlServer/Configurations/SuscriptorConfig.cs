using Exam.SqlServer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.SqlServer.Configurations;
public class SuscriptorConfig : IEntityTypeConfiguration<Suscriptor>
{
    public void Configure(EntityTypeBuilder<Suscriptor> builder)
    {
        builder.ToTable("Suscriptor").HasKey(p => p.IdSuscriptor).HasName("IdSuscriptor");
        builder.Property(p => p.Nombre).HasColumnType("varchar(100)").HasMaxLength(100);
        builder.Property(p => p.Apellido).HasColumnType("varchar(100)").HasMaxLength(100);
        builder.Property(p => p.NumeroDocumento).HasColumnType("varchar(200)").HasMaxLength(200);
        builder.Property(p => p.TipoDocumento).HasColumnType("int");
        builder.Property(p => p.Direccion).HasColumnType("varchar(300)").HasMaxLength(300);
        builder.Property(p => p.Telefono).HasColumnType("varchar(30)").HasMaxLength(30);
        builder.Property(p => p.Email).HasColumnType("varchar(100)").HasMaxLength(100);
        builder.Property(p => p.NombreUsuario).HasColumnType("varchar(100)").HasMaxLength(100);
        builder.Property(p => p.Password).HasColumnType("varchar(500)").HasMaxLength(500);
    }
}
