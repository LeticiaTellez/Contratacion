using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Contratacion.Datos.Configuraciones
{
    public class DocumentosRequeridoConfiguracion
    {
        public void Configure(EntityTypeBuilder<DocumentosRequerido> entity)
        {
            entity.ToTable("DocumentosRequeridos", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Prerequisito).HasColumnName("prerequisito");
        }
    }
}
