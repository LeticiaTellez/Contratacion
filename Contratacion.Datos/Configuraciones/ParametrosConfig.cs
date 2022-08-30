using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class ParametrosConfig : IEntityTypeConfiguration<ParametrosConfiguracion>
    {
        public void Configure(EntityTypeBuilder<ParametrosConfiguracion> builder)
        {
            builder.ToTable("ParametrosConfiguracion", "seguridad");
            builder.HasKey(c => c.IdParametro);
            builder.Property(c => c.NombreParametro).HasColumnType("nvarchar(250)");
            builder.Property(c => c.Alias).HasColumnType("nvarchar(250)").IsRequired();
            builder.Property(c => c.ValorFecha).HasColumnType("datetime");
            builder.Property(c => c.ValorNumerico).HasColumnType("float");
            builder.Property(c => c.ValorTexto).HasColumnType("nvarchar(800)");
            builder.Property(c => c.NombreCategoria).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
