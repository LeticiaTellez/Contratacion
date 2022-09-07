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
            Expedientes = new HashSet<Expediente>();
            ExperienciaExternos = new HashSet<ExperienciaExterno>();
            IdiomasExternos = new HashSet<IdiomasExterno>();
            ReferenciaParticularesExternos = new HashSet<ReferenciasExterno>();
            UsuariosExternos = new HashSet<UsuariosExterno>();
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public double? AspiracionSalarial { get; set; }
        public int Contratado { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Imagen { get; set; }
        public string Nacionalidad { get; set; }
        public string NoSeguroSocial { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdCargoAspirado { get; set; }
        public string NumLicencia { get; set; }
        public bool? Activo { get; set; }
        public int? IdRegionActual { get; set; }

        public virtual Cargo CargoAspirado { get; set; }
        public virtual Catalogo EstadoCivil { get; set; }
        public virtual Regiones RegionActual { get; set; }
        public virtual ICollection<EspecialidadExterno> EspecialidadExternos { get; set; }
        public virtual ICollection<EstudiosExterno> EstudiosExternos { get; set; }
        public virtual ICollection<Expediente> Expedientes { get; set; }
        public virtual ICollection<ExperienciaExterno> ExperienciaExternos { get; set; }
        public virtual ICollection<IdiomasExterno> IdiomasExternos { get; set; }
        public virtual ICollection<ReferenciasExterno> ReferenciaParticularesExternos { get; set; }
        public virtual ICollection<UsuariosExterno> UsuariosExternos { get; set; }
    }
}
