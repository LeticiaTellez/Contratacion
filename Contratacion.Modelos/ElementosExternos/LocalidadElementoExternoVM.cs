using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class LocalidadElementoExternoVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }
        public int IdElementoExterno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdMunicipio { get; set; }
        public string NombreMunicipio { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
    }
}
