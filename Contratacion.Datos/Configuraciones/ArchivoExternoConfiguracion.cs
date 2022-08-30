using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class ArchivoExternoConfiguracion : IEntityTypeConfiguration<ArchivoExterno>
    {
        public void Configure(EntityTypeBuilder<ArchivoExterno> builder)
        {
            builder.ToTable("ArchivoExterno", "contratacion");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Activo).HasColumnName("activo");
            builder.Property(e => e.FechaRecepcion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_recepcion");
            builder.Property(e => e.IdExpediente).HasColumnName("id_expediente");
            builder.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            builder.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            builder.Property(e => e.Ruta)
                .IsUnicode(false)
                .HasColumnName("ruta");

            builder.HasOne(d => d.Expediente)
                .WithMany(p => p.ArchivoExternos)
                .HasForeignKey(d => d.IdExpediente)
                .HasConstraintName("FKDA21305584239BDA");
            builder.HasOne(d => d.DocumentosRequerido)
                .WithMany(p => p.ArchivoExternos)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("FKDA21305519B7956B");
        }
    }
}
