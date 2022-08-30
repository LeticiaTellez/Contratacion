using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ExperienciaExterno
    {
        public int Id { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string FichaLaboral { get; set; }
        public string MotivoRetiro { get; set; }
        public string NombreJefe { get; set; }
        public double? SueldoMensual { get; set; }
        public int? IdExterno { get; set; }
        public int? IdEmpresa { get; set; }
        public bool? Activo { get; set; }
        public string CagoJefe { get; set; }
        public string CargoDesempenado { get; set; }

        public virtual ElementosExterno Externo { get; set; }
        public virtual Catalogo Empresa { get; set; }
    }
}
