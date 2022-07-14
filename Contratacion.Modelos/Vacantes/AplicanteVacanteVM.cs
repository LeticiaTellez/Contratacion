using System;
using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Vacantes
{
    public class AplicanteVacanteVM
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Campo Requerido")]
        public int IdVacante { get; set; }
        [Required(ErrorMessage = "Debes tener el CV creado para poder aplicar")]
        public int IdCandidato { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public double? AspiracionSalarial { get; set; }
        public string ComentariosAplicante { get; set; }
    }
}
