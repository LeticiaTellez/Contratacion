using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Seguridad
{
    public class EmailConfirmedRequest
    {
        [Required(ErrorMessage = "Campo Requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Code { get; set; }
    }
}
