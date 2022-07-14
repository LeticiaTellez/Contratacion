using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.Seguridad
{
    public class RegistrationRequest
    {
        [Required (ErrorMessage = "El nombre completo es requerido")] 
        public string FullName { get; set; }

        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "El formato de correo no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string Password { get; set; }
    }
}
