using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class AplicantesVacante : Base
    {
        public int IdVacante { get; set; }
        public int IdCandidato { get; set; }
        public bool? AceptacionTerminos { get; set; }
        public double? AspiracionSalarial { get; set; }
        public bool? EsDescartado { get; set; }
        public bool? EsPrechequeado { get; set; }
        public DateTime? FechaPrechequeo { get; set; }
        public bool? CalificaEntrevista { get; set; }
        public string ComentariosPrechequeo { get; set; }
        public string FormatoPrechequeo { get; set; }
        public int? IdMotivoDescarte { get; set; }
        public DateTime? FechaDescarte { get; set; }
        public string ComentariosAplicante { get; set; }

        public virtual MotivosDescarte MotivoDescarte { get; set; }
        public virtual Vacantes Vacante { get; set; }
    }
}
