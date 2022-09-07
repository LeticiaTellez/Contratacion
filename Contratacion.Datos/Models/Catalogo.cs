using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class Catalogo
    {
        public Catalogo()
        {
            Areas = new HashSet<Area>();
            CargoIdCategoriaCargo = new HashSet<Cargo>();
            CargoIdNivelEscolaridad = new HashSet<Cargo>();
            CargoIdTipoFuncionario = new HashSet<Cargo>();
            ElementosExternoEstadoCivil = new HashSet<ElementosExterno>();
            Especialidades = new HashSet<Especialidad>();
            EstudiosExternoIdEstudio = new HashSet<EstudiosExterno>();
            ExperienciaExternos = new HashSet<ExperienciaExterno>();
            IdiomasExternoIdCalificativo = new HashSet<IdiomasExterno>();
            ReferenciasExternoIdTipoReferencia = new HashSet<ReferenciasExterno>();
        }

        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Cargo> CargoIdCategoriaCargo { get; set; }
        public virtual ICollection<Cargo> CargoIdNivelEscolaridad { get; set; }
        public virtual ICollection<Cargo> CargoIdTipoFuncionario { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoEstadoCivil { get; set; }
        public virtual ICollection<Especialidad> Especialidades { get; set; }
        public virtual ICollection<EstudiosExterno> EstudiosExternoIdEstudio { get; set; }
        public virtual ICollection<ExperienciaExterno> ExperienciaExternos { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternoIdCalificativo { get; set; }
        public virtual ICollection<ReferenciasExterno> ReferenciasExternoIdTipoReferencia { get; set; }
    }
}
