using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class VacantesConfiguracion : BaseConfiguracion<Vacantes>
    {
        public override void Configure(EntityTypeBuilder<Vacantes> entity)
        {
            base.Configure(entity);

            entity.ToTable("Vacantes", "seleccion");

            entity.Property(e => e.DetallesVacante).HasColumnName("detalles_vacante");

            entity.Property(e => e.EsPublica).HasColumnName("es_publica");

            entity.Property(e => e.FechaFinPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin_publicacion");

            entity.Property(e => e.FechaInicioPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio_publicacion");

            entity.Property(e => e.FechaRecepcionRequisicion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_recepcion_requisicion");

            entity.Property(e => e.IdColaboradorEncargado).HasColumnName("id_colaborador_encargado");

            entity.Property(e => e.IdColaboradorRecibe).HasColumnName("id_colaborador_recibe");

            entity.Property(e => e.IdRequisicion).HasColumnName("id_requisicion");

            entity.Property(e => e.IdUsuarioCreacion).HasColumnName("id_usuario_creacion");

            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("id_usuario_modificacion");

            entity.Property(e => e.NivelRiesgoCargoActual).HasColumnName("nivel_riesgo_cargo_actual");

            entity.Property(e => e.NivelRiesgoCargoPrevio).HasColumnName("nivel_riesgo_cargo_previo");

            entity.Property(e => e.TipoSeleccion).HasColumnName("tipo_seleccion");

            entity.HasOne(d => d.Requisicion)
                .WithMany(p => p.Vacantes)
                .HasForeignKey(d => d.IdRequisicion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__vacantes__id_req__710B0E66");
        }
    }
}
