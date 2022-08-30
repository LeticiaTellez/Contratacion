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

            entity.HasOne(d => d.CatalogoEscribir)
                .WithMany(p => p.IdiomasExternoEscribir)
                .HasForeignKey(d => d.Escribir)
                .HasConstraintName("FK13BD995291113CFB");

            entity.HasOne(d => d.CatalogoEscuchar)
                .WithMany(p => p.IdiomasExternoEscuchar)
                .HasForeignKey(d => d.Escuchar)
                .HasConstraintName("FK13BD99529138DED2");

            entity.HasOne(d => d.CatalogoHablar)
                .WithMany(p => p.IdiomasExternoHablar)
                .HasForeignKey(d => d.Hablar)
                .HasConstraintName("FK13BD9952D9638C50");

            entity.HasOne(d => d.Calificativo)
                .WithMany(p => p.IdiomasExternoIdCalificativo)
                .HasForeignKey(d => d.IdCalificativo)
                .HasConstraintName("FK13BD9952C2B255AA");

            entity.HasOne(d => d.ElementoExterno)
                .WithMany(p => p.IdiomasExternos)
                .HasForeignKey(d => d.IdExterno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK13BD99527EA3FE11");

            entity.HasOne(d => d.CatalogoLeer)
                .WithMany(p => p.IdiomasExternoLeer)
                .HasForeignKey(d => d.Leer)
                .HasConstraintName("FK13BD9952229915C2");
        }
    }
}
