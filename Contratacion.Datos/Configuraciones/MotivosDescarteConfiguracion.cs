using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class MotivosDescarteConfiguracion : BaseConfiguracion<MotivosDescarte>
    {
        public override void Configure(EntityTypeBuilder<MotivosDescarte> entity)
        {
            base.Configure(entity);

            entity.ToTable("MotivosDescarte", "seleccion");

            entity.Property(e => e.Estado).HasColumnName("estado_motivo");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");

            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_modificacion");

            entity.Property(e => e.IdUsuarioCreacion).HasColumnName("id_usuario_creacion");

            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("id_usuario_modificacion");

            entity.Property(e => e.NombreMotivo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_motivo");

            entity.Property(e => e.TextoJustificativo).HasColumnName("texto_justificativo");
        }
    }
}
