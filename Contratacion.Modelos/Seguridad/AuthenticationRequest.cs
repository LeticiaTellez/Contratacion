using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Seguridad
{
    public class AuthenticationRequest
    {
        [Required(ErrorMessage = "Campo Requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Password { get; set; }
    }
}
