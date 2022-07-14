using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Seguridad
{
    public class ChangePasswordRequest
    {
        public string UserName { get; set; }
        [Required (ErrorMessage = "La contraseña actual es requerida")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "La nueva contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; }
    }

    public class ChangeEmailRequest 
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
