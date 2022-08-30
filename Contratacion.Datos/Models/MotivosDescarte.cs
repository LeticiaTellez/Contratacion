using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class MotivosDescarte : Base
    {
        public MotivosDescarte()
        {
            AplicantesVacantes = new HashSet<AplicantesVacante>();
        }

        public string NombreMotivo { get; set; }
        public string TextoJustificativo { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public int? IdUsuarioModificacion { get; set; }

        public virtual ICollection<AplicantesVacante> AplicantesVacantes { get; set; }
    }
}
