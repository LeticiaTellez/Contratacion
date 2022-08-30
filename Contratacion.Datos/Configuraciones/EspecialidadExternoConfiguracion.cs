using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class EspecialidadExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<EspecialidadExterno> entity)
        {
            entity.ToTable("EspecialidadExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Comentario)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("comentario");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");

            entity.HasOne(d => d.Externo)
                .WithMany(p => p.EspecialidadExternos)
                .HasForeignKey(d => d.IdExterno)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("especialidad_externo_fk");

            entity.HasOne(d => d.Especialidad)
                .WithMany(p => p.EspecialidadExternos)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("especialidad_externo_fk2");
        }
    }
}
