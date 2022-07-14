using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            EspecialidadXEexternos = new HashSet<EspecialidadXEexterno>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Especialidad1 { get; set; }
        public int? IdEstudio { get; set; }
        public bool? Activo { get; set; }

        public virtual Catalogo IdEstudioNavigation { get; set; }
        public virtual ICollection<EspecialidadXEexterno> EspecialidadXEexternos { get; set; }
    }
}
