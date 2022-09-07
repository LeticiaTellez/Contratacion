using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class EstudiosExterno
    {
        public int Id { get; set; }
        public int IdExterno { get; set; }
        public int IdEstudio { get; set; }
        public string Instituto { get; set; }
        public string Comentario { get; set; }
        public bool? Completado { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaIncio { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno Externo { get; set; }
        public virtual Catalogo Estudio { get; set; }
    }
}
