using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class CatalogoConfiguracion
    {
        public void Configure(EntityTypeBuilder<Catalogo> entity)
        {
            entity.ToTable("Catalogos", "contratacion");

            entity.HasIndex(e => e.Id, "UQ_catalogos_id")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.IdPadre).HasColumnName("id_padre");

            entity.Property(e => e.Nombre)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("nombre");

        }
    }
}
