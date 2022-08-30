using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class AreaConfiguracion : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> entity)
        {
            entity.ToTable("Areas", "configuracion");

            entity.HasIndex(e => e.Abreviacion, "UQ_area_abreviacion_areas")
                .IsUnique();

            entity.HasIndex(e => e.Codigo, "UQ_area_codigo_areas")
                .IsUnique();

            entity.HasIndex(e => e.Id, "UQ_area_id_areas")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Abreviacion)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("abreviacion");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            entity.Property(e => e.IdCentro).HasColumnName("id_centro");
            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");
            entity.Property(e => e.IdPadre).HasColumnName("id_padre");
            entity.Property(e => e.IdTipoArea).HasColumnName("id_tipo_area");
            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.TipoArea)
                .WithMany(p => p.Areas)
                .HasForeignKey(d => d.IdTipoArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("areas_fk");
        }
    }
}
