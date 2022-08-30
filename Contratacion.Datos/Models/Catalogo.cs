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
            ElementosExternoLicenciaConducir = new HashSet<ElementosExterno>();
            ElementosExternoNacionalidad = new HashSet<ElementosExterno>();
            ElementosExternoSexo = new HashSet<ElementosExterno>();
            ElementosExternoTipoSangre = new HashSet<ElementosExterno>();
            ElementosExternoUnidadEstatura = new HashSet<ElementosExterno>();
            ElementosExternoUnidadPeso = new HashSet<ElementosExterno>();
            Especialidades = new HashSet<Especialidad>();
            EstudiosExternoIdEstudio = new HashSet<EstudiosExterno>();
            EstudiosExternoInstituto = new HashSet<EstudiosExterno>();
            ExperienciaExternos = new HashSet<ExperienciaExterno>();
            IdiomasExternoEscribir = new HashSet<IdiomasExterno>();
            IdiomasExternoEscuchar = new HashSet<IdiomasExterno>();
            IdiomasExternoHablar = new HashSet<IdiomasExterno>();
            IdiomasExternoIdCalificativo = new HashSet<IdiomasExterno>();
            IdiomasExternoLeer = new HashSet<IdiomasExterno>();
            LocalidadExternoIdDepartamento = new HashSet<LocalidadExterno>();
            LocalidadExternoIdMunicipio = new HashSet<LocalidadExterno>();
            LocalidadElementoExternoIdPais = new HashSet<LocalidadExterno>();
            ReferenciasExternoIdRelacion = new HashSet<ReferenciasExterno>();
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
        public virtual ICollection<ElementosExterno> ElementosExternoLicenciaConducir { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoNacionalidad { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoSexo { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoTipoSangre { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoUnidadEstatura { get; set; }
        public virtual ICollection<ElementosExterno> ElementosExternoUnidadPeso { get; set; }
        public virtual ICollection<Especialidad> Especialidades { get; set; }
        public virtual ICollection<EstudiosExterno> EstudiosExternoIdEstudio { get; set; }
        public virtual ICollection<EstudiosExterno> EstudiosExternoInstituto { get; set; }
        public virtual ICollection<ExperienciaExterno> ExperienciaExternos { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternoEscribir { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternoEscuchar { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternoHablar { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternoIdCalificativo { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternoLeer { get; set; }
        public virtual ICollection<LocalidadExterno> LocalidadExternoIdDepartamento { get; set; }
        public virtual ICollection<LocalidadExterno> LocalidadExternoIdMunicipio { get; set; }
        public virtual ICollection<LocalidadExterno> LocalidadElementoExternoIdPais { get; set; }
        public virtual ICollection<ReferenciasExterno> ReferenciasExternoIdRelacion { get; set; }
        public virtual ICollection<ReferenciasExterno> ReferenciasExternoIdTipoReferencia { get; set; }
    }
}
