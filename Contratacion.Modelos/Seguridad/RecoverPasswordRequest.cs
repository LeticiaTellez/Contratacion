using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Seguridad
{
    public class RecoverPasswordRequest
    {
        public string UserName { get; set; }
        [Required (ErrorMessage = "La nueva contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
