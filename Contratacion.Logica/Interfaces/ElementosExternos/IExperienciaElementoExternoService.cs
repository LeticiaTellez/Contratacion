using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IExperienciaElementoExternoService
    {
        List<ExperienciaElementoExternoVM> ListarExperiencias(int idEexterno);
        GeneralResponse GuardarExperiencia(ExperienciaElementoExternoVM request);
        GeneralResponse ActualizarExperiencia(ExperienciaElementoExternoVM request);
        GeneralResponse EliminarExperiencia(int id);
    }
}
