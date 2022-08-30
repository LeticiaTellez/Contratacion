using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class EspecialidadConfiguracion
    {
        public void Configure(EntityTypeBuilder<Especialidad> entity)
        {
            entity.ToTable("Especialidades", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.IdEstudio).HasColumnName("id_estudio");

            entity.HasOne(d => d.Estudio)
                .WithMany(p => p.Especialidades)
                .HasForeignKey(d => d.IdEstudio)
                .HasConstraintName("FKD51FB932757CE933");
        }
    }
}
