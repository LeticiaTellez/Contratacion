using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class IdiomaExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<IdiomasExterno> entity)
        {
            entity.ToTable("IdiomasExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Escribir).HasColumnName("escribir");

            entity.Property(e => e.Escuchar).HasColumnName("escuchar");

            entity.Property(e => e.Hablar).HasColumnName("hablar");

            entity.Property(e => e.IdCalificativo).HasColumnName("id_calificativo");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.IdIdioma).HasColumnName("id_idioma");

            entity.Property(e => e.Leer).HasColumnName("leer");

            entity.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observaciones");

            entity.HasOne(d => d.Calificativo)
                .WithMany(p => p.IdiomasExternoIdCalificativo)
                .HasForeignKey(d => d.IdCalificativo)
                .HasConstraintName("FK13BD9952C2B255AA");

            entity.HasOne(d => d.ElementoExterno)
                .WithMany(p => p.IdiomasExternos)
                .HasForeignKey(d => d.IdExterno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK13BD99527EA3FE11");
        }
    }
}
