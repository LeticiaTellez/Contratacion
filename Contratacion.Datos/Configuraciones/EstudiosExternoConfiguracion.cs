using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class EstudiosExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<EstudiosExterno> entity)
        {
            entity.ToTable("EstudiosExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Comentario)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("comentario");

            entity.Property(e => e.Completado).HasColumnName("completado");

            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");

            entity.Property(e => e.FechaIncio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_incio");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.IdEstudio).HasColumnName("id_estudio");

            entity.Property(e => e.Instituto).HasColumnName("instituto");

            entity.HasOne(d => d.Externo)
                .WithMany(p => p.EstudiosExternos)
                .HasForeignKey(d => d.IdExterno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudios_externo_elemento_fk");

            entity.HasOne(d => d.Estudio)
                .WithMany(p => p.EstudiosExternoIdEstudio)
                .HasForeignKey(d => d.IdEstudio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estudios_externo_estudio_fk");
        }
    }
}
