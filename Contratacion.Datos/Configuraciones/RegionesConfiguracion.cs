using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class RegionesConfiguracion
    {
        public void Configure(EntityTypeBuilder<Regiones> entity)
        {
            entity.ToTable("Regiones", "configuracion");

            entity.HasIndex(e => e.Id, "UQ_regiones_id")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Codigo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.IdPadre).HasColumnName("id_padre");

            entity.Property(e => e.Latitud)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("latitud");

            entity.Property(e => e.Longitud)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("longitud");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Seleccionado).HasColumnName("seleccionado");
        }
    }
}
