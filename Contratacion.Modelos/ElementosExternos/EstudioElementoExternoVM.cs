using System;
using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class EstudioElementoExternoVM
    {
        public int? Id { get; set; }
        public int IdEexterno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstudio { get; set; }
        public string NombreEstudio { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreInstituto { get; set; }
        public string Comentario { get; set; }
        public bool? Completado { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime? FechaIncio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
