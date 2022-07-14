using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class EspecialidadElementoExternoVM
    {
        public int? Id { get; set; }
        public string Comentario { get; set; }
        public int? IdEexterno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int? IdEspecialidad { get; set; }
        public string NombreEspecialidad { get; set; }
    }
}
