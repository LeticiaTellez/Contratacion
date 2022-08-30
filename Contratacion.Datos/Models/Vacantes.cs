using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Vacantes : Base
    {
        public Vacantes()
        {
            AplicantesVacantes = new HashSet<AplicantesVacante>();
        }
        
        public int IdRequisicion { get; set; }
        public DateTime FechaRecepcionRequisicion { get; set; }
        public int IdColaboradorRecibe { get; set; }
        public double? NivelRiesgoCargoPrevio { get; set; }
        public double NivelRiesgoCargoActual { get; set; }
        public int IdColaboradorEncargado { get; set; }
        public DateTime FechaInicioPublicacion { get; set; }
        public DateTime FechaFinPublicacion { get; set; }
        public bool? EsPublica { get; set; }
        public int TipoSeleccion { get; set; }
        public string DetallesVacante { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        

        public virtual RequisicionPersonal Requisicion { get; set; }
        public virtual ICollection<AplicantesVacante> AplicantesVacantes { get; set; }
    }
}
