using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class IdiomaConfiguracion
    {
        public void Configure(EntityTypeBuilder<Idioma> entity)
        {
            entity.ToTable("Idiomas", "configuracion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CodigoIso)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_iso");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Seleccionado).HasColumnName("seleccionado");

            entity.Property(e => e.Traducido).HasColumnName("traducido");
        }
    }
}
