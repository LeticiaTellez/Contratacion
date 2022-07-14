using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IEspecialidadElementoExternoService
    {
        List<EspecialidadElementoExternoVM> ListarEspecialidades(int idEexterno);
        GeneralResponse GuardarEspecialidad(EspecialidadElementoExternoVM request);
        GeneralResponse ActualizarEspecialidad(EspecialidadElementoExternoVM request);
        GeneralResponse EliminarEspecialidad(int id);
    }
}
