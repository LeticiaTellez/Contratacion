using System;
using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class ExperienciaElementoExternoVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string FichaLaboral { get; set; }
        public string MotivoRetiro { get; set; }
        public string NombreJefe { get; set; }
        public double? SueldoMensual { get; set; }
        public int? IdEexterno { get; set; }
        public int? IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string CagoJefe { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string CargoDesempenado { get; set; }
    }
}
