using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ReferenciasExterno
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string NombreReferencia { get; set; }
        public string Ocupacion { get; set; }
        public string Telefono { get; set; }
        public int? IdTipoReferencia { get; set; }
        public bool? Activo { get; set; }
        public int? IdExterno { get; set; }

        public virtual ElementosExterno ElementoExterno { get; set; }
        public virtual Catalogo TipoReferencia { get; set; }
    }
}
