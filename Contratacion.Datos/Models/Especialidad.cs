using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            EspecialidadExternos = new HashSet<EspecialidadExterno>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdEstudio { get; set; }
        public bool? Activo { get; set; }

        public virtual Catalogo Estudio { get; set; }
        public virtual ICollection<EspecialidadExterno> EspecialidadExternos { get; set; }
    }
}
