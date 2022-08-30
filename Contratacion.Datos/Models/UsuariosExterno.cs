using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class UsuariosExterno
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdExterno { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno ElementoExterno { get; set; }
    }
}
