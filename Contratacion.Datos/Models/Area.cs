using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Area
    {
        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public int IdTipoArea { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public bool? Estado { get; set; }
        public string Descripcion { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdCentro { get; set; }

        public virtual Catalogo TipoArea { get; set; }
    }
}
