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
            CargoIdCategoriaCargoNavigations = new HashSet<Cargo>();
            CargoIdNivelEscolaridadNavigations = new HashSet<Cargo>();
            CargoIdTipoFuncionarioNavigations = new HashSet<Cargo>();
            ElementosExternoEstadoCivilNavigations = new HashSet<ElementosExterno>();
            ElementosExternoLicenciaConducirNavigations = new HashSet<ElementosExterno>();
            ElementosExternoNacionalidadNavigations = new HashSet<ElementosExterno>();
            ElementosExternoSexoNavigations = new HashSet<ElementosExterno>();
            ElementosExternoTipoSangreNavigations = new HashSet<ElementosExterno>();
            ElementosExternoUnidadEstaturaNavigations = new HashSet<ElementosExterno>();
            ElementosExternoUnidadPesoNavigations = new HashSet<ElementosExterno>();
            Especialidads = new HashSet<Especialidad>();
            EstudiosXEexternoIdEstudioNavigations = new HashSet<EstudiosXEexterno>();
            EstudiosXEexternoInstitutoNavigations = new HashSet<EstudiosXEexterno>();
            ExperienciaXEexternos = new HashSet<ExperienciaXEexterno>();
            IdiomasXEexternoEscribirNavigations = new HashSet<IdiomasXEexterno>();
            IdiomasXEexternoEscucharNavigations = new HashSet<IdiomasXEexterno>();
            IdiomasXEexternoHablarNavigations = new HashSet<IdiomasXEexterno>();
            IdiomasXEexternoIdCalificativoNavigations = new HashSet<IdiomasXEexterno>();
            IdiomasXEexternoLeerNavigations = new HashSet<IdiomasXEexterno>();
            LocalidadElementoExternoIdDepartamentoNavigations = new HashSet<LocalidadElementoExterno>();
            LocalidadElementoExternoIdMunicipioNavigations = new HashSet<LocalidadElementoExterno>();
            LocalidadElementoExternoIdPaisNavigations = new HashSet<LocalidadElementoExterno>();
            ReferenciaParticularesEexternoIdRelacionNavigations = new HashSet<ReferenciaParticularesEexterno>();
            ReferenciaParticularesEexternoIdTipoReferenciaNavigations = new HashSet<ReferenciaParticularesEexterno>();
        }

        public int Id { get; set; }
        public int? IdPadre { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<Cargo> CargoIdCategoriaCargoNavigations { get; set; }
        public virtual ICollection<Cargo> CargoIdNivelEscolaridadNavigations { get; set; }
        public virtual ICollection<Cargo> CargoIdTipoFuncionarioNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoEstadoCivilNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoLicenciaConducirNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoNacionalidadNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoSexoNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoTipoSangreNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoUnidadEstaturaNavigations { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoUnidadPesoNavigations { get; set; }
        public virtual ICollection<Especialidad> Especialidads { get; set; }
        public virtual ICollection<EstudiosXEexterno> EstudiosXEexternoIdEstudioNavigations { get; set; }
        public virtual ICollection<EstudiosXEexterno> EstudiosXEexternoInstitutoNavigations { get; set; }
        public virtual ICollection<ExperienciaXEexterno> ExperienciaXEexternos { get; set; }
        public virtual ICollection<IdiomasXEexterno> IdiomasXEexternoEscribirNavigations { get; set; }
        public virtual ICollection<IdiomasXEexterno> IdiomasXEexternoEscucharNavigations { get; set; }
        public virtual ICollection<IdiomasXEexterno> IdiomasXEexternoHablarNavigations { get; set; }
        public virtual ICollection<IdiomasXEexterno> IdiomasXEexternoIdCalificativoNavigations { get; set; }
        public virtual ICollection<IdiomasXEexterno> IdiomasXEexternoLeerNavigations { get; set; }
        public virtual ICollection<LocalidadElementoExterno> LocalidadElementoExternoIdDepartamentoNavigations { get; set; }
        public virtual ICollection<LocalidadElementoExterno> LocalidadElementoExternoIdMunicipioNavigations { get; set; }
        public virtual ICollection<LocalidadElementoExterno> LocalidadElementoExternoIdPaisNavigations { get; set; }
        public virtual ICollection<ReferenciaParticularesEexterno> ReferenciaParticularesEexternoIdRelacionNavigations { get; set; }
        public virtual ICollection<ReferenciaParticularesEexterno> ReferenciaParticularesEexternoIdTipoReferenciaNavigations { get; set; }
    }
}
