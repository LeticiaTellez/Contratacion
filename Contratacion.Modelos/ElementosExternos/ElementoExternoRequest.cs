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
        public string Nacionalidad { get; set; }
        public string NoPasaporte { get; set; }
        public string NoSeguroSocial { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public int IdEstadoCivil { get; set; }
        public int? CargoAspirado { get; set; }
        public int? IdRegionActual { get; set; }
        public string Codigo { get; set; }
        public int IdUsuario { get; set; }
    }

    public class IdRequest 
    {
        public int Id { get; set; }
    }
}
