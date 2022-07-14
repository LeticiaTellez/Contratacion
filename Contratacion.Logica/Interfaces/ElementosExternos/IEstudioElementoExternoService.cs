using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IEstudioElementoExternoService
    {
        List<EstudioElementoExternoVM> ListarEstudios(int idEexterno);
        GeneralResponse GuardarEstudio(EstudioElementoExternoVM request);
        GeneralResponse ActualizarEstudio(EstudioElementoExternoVM request);
        GeneralResponse EliminarEstudio(int id);
    }
}
