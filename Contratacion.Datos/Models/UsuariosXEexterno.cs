using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class UsuariosXEexterno
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdEexterno { get; set; }
        public bool? Activo { get; set; }

        public virtual ElementosExterno IdEexternoNavigation { get; set; }
    }
}
