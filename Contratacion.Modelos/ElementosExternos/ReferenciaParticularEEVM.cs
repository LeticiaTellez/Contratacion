using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class ReferenciaParticularEEVM
    {
        public int? Id { get; set; }
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreReferencia { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Ocupacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Telefono { get; set; }
        public int? IdTipoReferencia { get; set; }
        public string NombreTipoReferencia { get; set; }
        public int? IdExterno { get; set; }
    }
}
