using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class IdiomasXEexterno
    {
        public int Id { get; set; }
        public int IdIdioma { get; set; }
        public int IdEexterno { get; set; }
        public bool? Activo { get; set; }
        public string Observaciones { get; set; }
        public int? Escribir { get; set; }
        public int? Escuchar { get; set; }
        public int? Hablar { get; set; }
        public int? Leer { get; set; }
        public int? IdCalificativo { get; set; }

        public virtual Catalogo EscribirNavigation { get; set; }
        public virtual Catalogo EscucharNavigation { get; set; }
        public virtual Catalogo HablarNavigation { get; set; }
        public virtual Catalogo IdCalificativoNavigation { get; set; }
        public virtual ElementosExterno IdEexternoNavigation { get; set; }
        public virtual Catalogo LeerNavigation { get; set; }
    }
}
