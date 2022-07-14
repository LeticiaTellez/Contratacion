using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IIdiomaElementoExternoService
    {
        List<IdiomaElementoExternoVM> ListarIdiomas(int idEexterno);
        GeneralResponse GuardarIdioma(IdiomaElementoExternoVM request);
        GeneralResponse ActualizarIdioma(IdiomaElementoExternoVM request);
        GeneralResponse EliminarIdioma(int id);
    }
}
