using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            ElementosExternos = new HashSet<ElementosExterno>();
        }

        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public string Nombre { get; set; }
        public int IdNivelEscolaridad { get; set; }
        public int IdGrupoEscala { get; set; }
        public int IdCategoriaCargo { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public string DescripcionGenerica { get; set; }
        public string Observaciones { get; set; }
        public double? SalarioBase { get; set; }
        public int? Estado { get; set; }
        public int? IdSolicitante { get; set; }
        public bool? Activo { get; set; }
        public string Codigo { get; set; }
        public double? SalarioHasta { get; set; }
        public int? IdTipoFuncionario { get; set; }

        public virtual Catalogo CategoriaCargo { get; set; }
        public virtual Catalogo NivelEscolaridad { get; set; }
        public virtual Catalogo TipoFuncionario { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternos { get; set; }
    }
}
