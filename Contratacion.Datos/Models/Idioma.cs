using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Idioma
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Traducido { get; set; }
        public bool? Estado { get; set; }
        public bool? Seleccionado { get; set; }
        public string CodigoIso { get; set; }
    }
}
