using Contratacion.Modelos;
using Contratacion.Modelos.Vacantes;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.Vacantes
{
    public interface IVacanteService
    {
        List<VacanteVM> ListarVacantes();
        List<AreaResponse> ListarAreas();
    }
}
