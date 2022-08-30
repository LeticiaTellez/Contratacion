using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class LocalidadExterno
    {
        public int Id { get; set; }
        public byte? EstaActivo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdElementoExterno { get; set; }
        public int IdMunicipio { get; set; }
        public int IdPais { get; set; }

        public virtual Catalogo Departamento { get; set; }
        public virtual ElementosExterno ElementoExterno { get; set; }
        public virtual Catalogo Municipio { get; set; }
        public virtual Catalogo Pais { get; set; }
    }
}
