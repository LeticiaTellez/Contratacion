using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class LocalidadElementoExterno
    {
        public int Id { get; set; }
        public byte? EstaActivo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdElementoExterno { get; set; }
        public int IdMunicipio { get; set; }
        public int IdPais { get; set; }

        public virtual Catalogo IdDepartamentoNavigation { get; set; }
        public virtual ElementosExterno IdElementoExternoNavigation { get; set; }
        public virtual Catalogo IdMunicipioNavigation { get; set; }
        public virtual Catalogo IdPaisNavigation { get; set; }
    }
}
