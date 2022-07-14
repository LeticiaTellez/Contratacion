using System;

namespace Contratacion.Modelos.Vacantes
{
    public class VacanteVM
    {
        public int Id { get; set; }
        public int IdArea { get; set; }
        public string NombreCargo { get; set; }
        public string NombreTipoContrato { get; set; }
        public string NombreSucursal { get; set; }
        public string DescripcionCargo { get; set; }
        public string DetallesVacante { get; set; }
        public double SalarioMaximo { get; set; }
        public DateTime FechaInicioPublicacion { get; set; }
        public DateTime FechaFinPublicacion { get; set; }
    }
}
