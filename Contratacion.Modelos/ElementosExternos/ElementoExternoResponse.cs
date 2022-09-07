namespace Contratacion.Modelos.ElementosExternos
{
    public class ElementoExternoResponse : ElementoExternoRequest
    {
        public string NombreNacionalidad { get; set; }
        public string NombreSexo { get; set; }
        public string NombreEstadoCivil { get; set; }
        public string NombreCargoAspirado { get; set; }
        public string NombreRegionActual { get; set; }
    }
}
