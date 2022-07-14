using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class EspecialidadXEexterno
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? IdEexterno { get; set; }
        public int? IdEspecialidad { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno IdEexternoNavigation { get; set; }
        public virtual Especialidad IdEspecialidadNavigation { get; set; }
    }
}
