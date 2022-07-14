using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class MotivosDescarte
    {
        public MotivosDescarte()
        {
            AplicantesVacantes = new HashSet<AplicantesVacante>();
        }

        public int Id { get; set; }
        public string NombreMotivo { get; set; }
        public string TextoJustificativo { get; set; }
        public bool? EstadoMotivo { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<AplicantesVacante> AplicantesVacantes { get; set; }
    }
}
