using System;
using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class ArchivoElementoExternoVM
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int? IdTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }
        public int? IdExpediente { get; set; }
        public int IdEexterno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Ruta { get; set; }
        public DateTime? FechaRecepcion { get; set; }
    }
}
