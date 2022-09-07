using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class ExpedienteConfiguracion
    {
        public void Configure(EntityTypeBuilder<Expediente> entity)
        {
            entity.ToTable("Expedientes", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("codigo");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");

            entity.HasOne(d => d.Externo)
                .WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.IdExterno)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("expediente_externo_fk");
        }
    }
}
