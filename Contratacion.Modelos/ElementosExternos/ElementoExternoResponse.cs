namespace Contratacion.Modelos.ElementosExternos
{
    public class ElementoExternoResponse : ElementoExternoRequest
    {
        public string NombreLicenciaConducir { get; set; }
        public string NombreNacionalidad { get; set; }
        public string NombreSexo { get; set; }
        public string NombreTipoSangre { get; set; }
        public string NombreEstadoCivil { get; set; }
        public string NombreCargoAspirado { get; set; }
        public string NombreRegionActual { get; set; }
        public string NombreRegionNatal { get; set; }
        public string NombreUnidadEstatura { get; set; }
        public string NombreUnidadPeso { get; set; }
    }
}
