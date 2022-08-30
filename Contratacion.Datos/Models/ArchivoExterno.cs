using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ArchivoExterno
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? IdExpediente { get; set; }
        public bool? Activo { get; set; }
        public string Ruta { get; set; }
        public DateTime? FechaRecepcion { get; set; }

        public virtual Expediente Expediente { get; set; }
        public virtual DocumentosRequerido DocumentosRequerido { get; set; }
    }
}
