using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class DocumentosRequerido
    {
        public DocumentosRequerido()
        {
            ArchivoExternos = new HashSet<ArchivoExterno>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }
        public bool? Prerequisito { get; set; }

        public virtual ICollection<ArchivoExterno> ArchivoExternos { get; set; }
    }
}
