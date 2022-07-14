using Contratacion.Modelos;
using Contratacion.Modelos.Vacantes;

namespace Contratacion.Logica.Interfaces.Vacantes
{
    public interface IAplicanteVacanteService
    {
        GeneralResponse GuardarAplicacion(AplicanteVacanteVM request);
    }
}
