using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ReferenciaParticularesEexterno
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string NombreReferencia { get; set; }
        public string Ocupacion { get; set; }
        public string Telefono { get; set; }
        public int? IdTipoReferencia { get; set; }
        public bool? Activo { get; set; }
        public int? IdEexterno { get; set; }
        public int? IdRelacion { get; set; }

        public virtual ElementosExterno IdEexternoNavigation { get; set; }
        public virtual Catalogo IdRelacionNavigation { get; set; }
        public virtual Catalogo IdTipoReferenciaNavigation { get; set; }
    }
}
