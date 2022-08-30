using System;
using System.Collections.Generic;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ElementosExterno
    {
        public ElementosExterno()
        {
            EspecialidadExternos = new HashSet<EspecialidadExterno>();
            EstudiosExternos = new HashSet<EstudiosExterno>();
            ExpedienteTmps = new HashSet<Expediente>();
            ExperienciaExternos = new HashSet<ExperienciaExterno>();
            IdiomasExternos = new HashSet<IdiomasExterno>();
            LocalidadElementoExternos = new HashSet<LocalidadExterno>();
            ReferenciaParticularesExternos = new HashSet<ReferenciasExterno>();
            UsuariosExternos = new HashSet<UsuariosExterno>();
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
        public int? IdLicenciaConducir { get; set; }
        public int? IdNacionalidad { get; set; }
        public string NoPasaporte { get; set; }
        public string NoSeguroSocial { get; set; }
        public string Nombres { get; set; }
        public double? Peso { get; set; }
        public int? IdSexo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public int? IdTipoSangre { get; set; }
        public int IdEstadoCivil { get; set; }
        public int? IdCargoAspirado { get; set; }
        public string NumLicencia { get; set; }
        public bool? Activo { get; set; }
        public double? Estatura { get; set; }
        public int? IdRegionActual { get; set; }
        public int? IdRegionNatal { get; set; }
        public int? IdUnidadEstatura { get; set; }
        public int? IdUnidadPeso { get; set; }
        public string Codigo { get; set; }

        public virtual Cargo CargoAspirado { get; set; }
        public virtual Catalogo EstadoCivil { get; set; }
        public virtual Regiones RegionActual { get; set; }
        public virtual Regiones RegionNatal { get; set; }
        public virtual Catalogo LicenciaConducir { get; set; }
        public virtual Catalogo Nacionalidad { get; set; }
        public virtual Catalogo Sexo { get; set; }
        public virtual Catalogo TipoSangre { get; set; }
        public virtual Catalogo UnidadEstatura { get; set; }
        public virtual Catalogo UnidadPeso { get; set; }
        public virtual ICollection<EspecialidadExterno> EspecialidadExternos { get; set; }
        public virtual ICollection<EstudiosExterno> EstudiosExternos { get; set; }
        public virtual ICollection<Expediente> ExpedienteTmps { get; set; }
        public virtual ICollection<ExperienciaExterno> ExperienciaExternos { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternos { get; set; }
        public virtual ICollection<LocalidadExterno> LocalidadElementoExternos { get; set; }
        public virtual ICollection<ReferenciasExterno> ReferenciaParticularesExternos { get; set; }
        public virtual ICollection<UsuariosExterno> UsuariosExternos { get; set; }
    }
}
