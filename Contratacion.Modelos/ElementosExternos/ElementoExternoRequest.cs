using System;
using System.ComponentModel.DataAnnotations;

namespace Contratacion.Modelos.ElementosExternos
{
    public class ElementoExternoRequest
    {
        public int? Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public double? AspiracionSalarial { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Imagen { get; set; }
        public int? LicenciaConducir { get; set; }
        public int? Nacionalidad { get; set; }
        public string NoPasaporte { get; set; }
        public string NoSeguroSocial { get; set; }
        public double? Peso { get; set; }
        public int? Sexo { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public int? TipoSangre { get; set; }
        public int EstadoCivil { get; set; }
        public int? CargoAspirado { get; set; }
        public string NumLicencia { get; set; }
        public double? Estatura { get; set; }
        public int? IdRegionActual { get; set; }
        public int? IdRegionNatal { get; set; }
        public int? UnidadEstatura { get; set; }
        public int? UnidadPeso { get; set; }
        public string Codigo { get; set; }
        public int IdUsuario { get; set; }
    }

    public class IdRequest 
    {
        public int Id { get; set; }
    }
}
