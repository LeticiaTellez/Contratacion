using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Expediente
    {
        public Expediente()
        {
            ArchivoExternos = new HashSet<ArchivoExterno>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Observaciones { get; set; }
        public int? IdExterno { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno Externo { get; set; }
        public virtual ICollection<ArchivoExterno> ArchivoExternos { get; set; }
    }
}
