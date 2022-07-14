using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class RequisicionPersonal
    {
        public RequisicionPersonal()
        {
            Vacantes = new HashSet<Vacante>();
        }

        public int Id { get; set; }
        public DateTime FechaRequisicion { get; set; }
        public int IdJustificacionRequisicion { get; set; }
        public string DetalleJustificacion { get; set; }
        public int IdMotivoRequisicion { get; set; }
        public DateTime? InicioMotivo { get; set; }
        public DateTime? FinMotivo { get; set; }
        public int IdTipoContratacion { get; set; }
        public int IdAreaRequisicion { get; set; }
        public int IdSucursalRequisicion { get; set; }
        public int IdColaboradorSolicita { get; set; }
        public int IdCargoColaboradorSolicita { get; set; }
        public int IdCargoSolicitado { get; set; }
        public double? SalarioMaximoCargo { get; set; }
        public double RangoInicioSalarioConfirmado { get; set; }
        public double? PeriodoEvaluacionMeses { get; set; }
        public string DescripcionRequisicion { get; set; }
        public string ObservacionesRequisicion { get; set; }
        public bool? Autorizado { get; set; }
        public bool? Rechazado { get; set; }
        public string MotivoRechazo { get; set; }
        public int IdEstadoRequisicion { get; set; }
        public int IdPasoAutorizacion { get; set; }
        public bool? Cerrada { get; set; }
        public bool? EstadoRequisicion { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<Vacante> Vacantes { get; set; }
    }
}
