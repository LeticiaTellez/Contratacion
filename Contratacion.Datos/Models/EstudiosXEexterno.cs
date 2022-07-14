using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class EstudiosXEexterno
    {
        public int Id { get; set; }
        public int IdEexterno { get; set; }
        public int IdEstudio { get; set; }
        public int Instituto { get; set; }
        public string Comentario { get; set; }
        public bool? Completado { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaIncio { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno IdEexternoNavigation { get; set; }
        public virtual Catalogo IdEstudioNavigation { get; set; }
        public virtual Catalogo InstitutoNavigation { get; set; }
    }
}
