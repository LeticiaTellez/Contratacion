using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Region
    {
        public Region()
        {
            ElementosExternoIdRegionActualNavigations = new HashSet<ElementosExterno>();
            ElementosExternoIdRegionNatalNavigations = new HashSet<ElementosExterno>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? IdPadre { get; set; }
        public string Codigo { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }
        public bool? Estado { get; set; }
        public bool? Seleccionado { get; set; }

        public virtual ICollection<ElementosExterno> ElementosExternoIdRegionActualNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoIdRegionNatalNavigations { get; set; }
    }
}
