using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Seguridad
{
    public class RecoveryEmailRequest
    {
        [Required(ErrorMessage = "Correo Requerido")]
        [EmailAddress(ErrorMessage = "El formato de correo no es válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "URL Requerida")]
        public string Url { get; set; }
    }
}
