using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ExpedienteTmp
    {
        public ExpedienteTmp()
        {
            ArchivoXExternos = new HashSet<ArchivoXExterno>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Observaciones { get; set; }
        public int? IdEexterno { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno IdEexternoNavigation { get; set; }
        public virtual ICollection<ArchivoXExterno> ArchivoXExternos { get; set; }
    }
}
