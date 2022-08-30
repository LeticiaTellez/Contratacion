using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class ReferenciasExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<ReferenciasExterno> entity)
        {
            entity.ToTable("ReferenciaExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.IdRelacion).HasColumnName("id_relacion");

            entity.Property(e => e.IdTipoReferencia).HasColumnName("id_tipo_referencia");

            entity.Property(e => e.NombreReferencia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_referencia");

            entity.Property(e => e.Ocupacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ocupacion");

            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.ElementoExterno)
                .WithMany(p => p.ReferenciaParticularesExternos)
                .HasForeignKey(d => d.IdExterno)
                .HasConstraintName("FK365BF1B97EA3FE11");

            entity.HasOne(d => d.Relacion)
                .WithMany(p => p.ReferenciasExternoIdRelacion)
                .HasForeignKey(d => d.IdRelacion)
                .HasConstraintName("FK365BF1B98535682D");

            entity.HasOne(d => d.TipoReferencia)
                .WithMany(p => p.ReferenciasExternoIdTipoReferencia)
                .HasForeignKey(d => d.IdTipoReferencia)
                .HasConstraintName("FK365BF1B997E0A795");
        }
    }
}
