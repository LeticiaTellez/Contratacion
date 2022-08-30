using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class AplicantesVacanteConfiguracion : BaseConfiguracion<AplicantesVacante>
    {
        public override void Configure(EntityTypeBuilder<AplicantesVacante> builder)
        { 
            base.Configure(builder);

            builder.ToTable("AplicantesVacante", "seleccion");
            builder.Property(e => e.AceptacionTerminos).HasColumnName("aceptacion_terminos");
            builder.Property(e => e.AspiracionSalarial).HasColumnName("aspiracion_salarial");
            builder.Property(e => e.CalificaEntrevista).HasColumnName("califica_entrevista");
            builder.Property(e => e.ComentariosAplicante).HasColumnName("comentarios_aplicante");
            builder.Property(e => e.ComentariosPrechequeo).HasColumnName("comentarios_prechequeo");
            builder.Property(e => e.EsDescartado).HasColumnName("es_descartado");
            builder.Property(e => e.EsPrechequeado).HasColumnName("es_prechequeado");
            builder.Property(e => e.FechaDescarte)
                .HasColumnType("datetime")
                .HasColumnName("fecha_descarte");
            builder.Property(e => e.FechaPrechequeo)
                .HasColumnType("datetime")
                .HasColumnName("fecha_prechequeo");
            builder.Property(e => e.FormatoPrechequeo).HasColumnName("formato_prechequeo");
            builder.Property(e => e.IdCandidato).HasColumnName("id_candidato");
            builder.Property(e => e.IdMotivoDescarte).HasColumnName("id_motivo_descarte");
            builder.Property(e => e.IdVacante).HasColumnName("id_vacante");

            builder.HasOne(d => d.MotivoDescarte)
                .WithMany(p => p.AplicantesVacantes)
                .HasForeignKey(d => d.IdMotivoDescarte)
                .HasConstraintName("FK__aplicante__id_mo__74DB9F4A");
            builder.HasOne(d => d.Vacante)
                .WithMany(p => p.AplicantesVacantes)
                .HasForeignKey(d => d.IdVacante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aplicante__id_va__73E77B11");
        }
    }
}
