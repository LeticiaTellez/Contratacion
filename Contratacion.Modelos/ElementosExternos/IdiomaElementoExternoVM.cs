using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class IdiomaElementoExternoVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdIdioma { get; set; }
        public string NombreIdioma { get; set; }
        public int IdEexterno { get; set; }
        public string Observaciones { get; set; }
        public int? Escribir { get; set; }
        public int? Escuchar { get; set; }
        public int? Hablar { get; set; }
        public int? Leer { get; set; }
        public int? IdCalificativo { get; set; }
        public string NombreCalificativo { get; set; }
    }
}
