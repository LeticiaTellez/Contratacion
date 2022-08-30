using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class RequisicionPersonalConfiguracion : BaseConfiguracion<RequisicionPersonal>
    {
        public override void Configure(EntityTypeBuilder<RequisicionPersonal> entity)
        {
            base.Configure(entity);

            entity.ToTable("RequisicionPersonal", "seleccion");

            entity.Property(e => e.Autorizado).HasColumnName("autorizado");

            entity.Property(e => e.Cerrada).HasColumnName("cerrada");

            entity.Property(e => e.DescripcionRequisicion).HasColumnName("descripcion_requisicion");

            entity.Property(e => e.DetalleJustificacion)
                .HasMaxLength(100)
                .HasColumnName("detalle_justificacion");

            entity.Property(e => e.FechaRequisicion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_requisicion");

            entity.Property(e => e.FinMotivo)
                .HasColumnType("datetime")
                .HasColumnName("fin_motivo");

            entity.Property(e => e.IdAreaRequisicion).HasColumnName("id_area_requisicion");

            entity.Property(e => e.IdCargoColaboradorSolicita).HasColumnName("id_cargo_colaborador_solicita");

            entity.Property(e => e.IdCargoSolicitado).HasColumnName("id_cargo_solicitado");

            entity.Property(e => e.IdColaboradorSolicita).HasColumnName("id_colaborador_solicita");

            entity.Property(e => e.IdEstadoRequisicion).HasColumnName("id_estado_requisicion");

            entity.Property(e => e.IdJustificacionRequisicion).HasColumnName("id_justificacion_requisicion");

            entity.Property(e => e.IdMotivoRequisicion).HasColumnName("id_motivo_requisicion");

            entity.Property(e => e.IdPasoAutorizacion).HasColumnName("id_paso_autorizacion");

            entity.Property(e => e.IdSucursalRequisicion).HasColumnName("id_sucursal_requisicion");

            entity.Property(e => e.IdTipoContratacion).HasColumnName("id_tipo_contratacion");

            entity.Property(e => e.IdUsuarioCreacion).HasColumnName("id_usuario_creacion");

            entity.Property(e => e.IdUsuarioModificacion).HasColumnName("id_usuario_modificacion");

            entity.Property(e => e.InicioMotivo)
                .HasColumnType("datetime")
                .HasColumnName("inicio_motivo");

            entity.Property(e => e.MotivoRechazo)
                .HasMaxLength(300)
                .HasColumnName("motivo_rechazo");

            entity.Property(e => e.ObservacionesRequisicion).HasColumnName("observaciones_requisicion");

            entity.Property(e => e.PeriodoEvaluacionMeses).HasColumnName("periodo_evaluacion_meses");

            entity.Property(e => e.RangoInicioSalarioConfirmado).HasColumnName("rango_inicio_salario_confirmado");

            entity.Property(e => e.Rechazado).HasColumnName("rechazado");

            entity.Property(e => e.SalarioMaximoCargo).HasColumnName("salario_maximo_cargo");

        }
    }
}
