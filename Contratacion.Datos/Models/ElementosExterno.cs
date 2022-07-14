using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ElementosExterno
    {
        public ElementosExterno()
        {
            EspecialidadXEexternos = new HashSet<EspecialidadXEexterno>();
            EstudiosXEexternos = new HashSet<EstudiosXEexterno>();
            ExpedienteTmps = new HashSet<ExpedienteTmp>();
            ExperienciaXEexternos = new HashSet<ExperienciaXEexterno>();
            IdiomasXEexternos = new HashSet<IdiomasXEexterno>();
            LocalidadElementoExternos = new HashSet<LocalidadElementoExterno>();
            ReferenciaParticularesEexternos = new HashSet<ReferenciaParticularesEexterno>();
            UsuariosXEexternos = new HashSet<UsuariosXEexterno>();
        }

        public int Id { get; set; }
        public string Apellidos { get; set; }
        public double? AspiracionSalarial { get; set; }
        public int Contratado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Imagen { get; set; }
        public int? LicenciaConducir { get; set; }
        public int? Nacionalidad { get; set; }
        public string NoPasaporte { get; set; }
        public string NoSeguroSocial { get; set; }
        public string Nombres { get; set; }
        public double? Peso { get; set; }
        public int? Sexo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public int? TipoSangre { get; set; }
        public int EstadoCivil { get; set; }
        public int? CargoAspirado { get; set; }
        public string NumLicencia { get; set; }
        public bool? Activo { get; set; }
        public double? Estatura { get; set; }
        public int? IdRegionActual { get; set; }
        public int? IdRegionNatal { get; set; }
        public int? UnidadEstatura { get; set; }
        public int? UnidadPeso { get; set; }
        public string Codigo { get; set; }

        public virtual Cargo CargoAspiradoNavigation { get; set; }
        public virtual Catalogo EstadoCivilNavigation { get; set; }
        public virtual Region IdRegionActualNavigation { get; set; }
        public virtual Region IdRegionNatalNavigation { get; set; }
        public virtual Catalogo LicenciaConducirNavigation { get; set; }
        public virtual Catalogo NacionalidadNavigation { get; set; }
        public virtual Catalogo SexoNavigation { get; set; }
        public virtual Catalogo TipoSangreNavigation { get; set; }
        public virtual Catalogo UnidadEstaturaNavigation { get; set; }
        public virtual Catalogo UnidadPesoNavigation { get; set; }
        public virtual ICollection<EspecialidadXEexterno> EspecialidadXEexternos { get; set; }
        public virtual ICollection<EstudiosXEexterno> EstudiosXEexternos { get; set; }
        public virtual ICollection<ExpedienteTmp> ExpedienteTmps { get; set; }
        public virtual ICollection<ExperienciaXEexterno> ExperienciaXEexternos { get; set; }
        public virtual ICollection<IdiomasXEexterno> IdiomasXEexternos { get; set; }
        public virtual ICollection<LocalidadElementoExterno> LocalidadElementoExternos { get; set; }
        public virtual ICollection<ReferenciaParticularesEexterno> ReferenciaParticularesEexternos { get; set; }
        public virtual ICollection<UsuariosXEexterno> UsuariosXEexternos { get; set; }
    }
}
