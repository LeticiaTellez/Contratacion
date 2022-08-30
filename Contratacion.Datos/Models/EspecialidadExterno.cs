using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class EspecialidadExterno
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int? IdExterno { get; set; }
        public int? IdEspecialidad { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno Externo { get; set; }
        public virtual Especialidad Especialidad { get; set; }
    }
}
