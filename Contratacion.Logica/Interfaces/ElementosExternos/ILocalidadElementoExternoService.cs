using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface ILocalidadElementoExternoService
    {
        List<LocalidadElementoExternoVM> ListarLocalidades(int idEexterno);
        GeneralResponse GuardarLocalidad(LocalidadElementoExternoVM request);
        GeneralResponse ActualizarLocalidad(LocalidadElementoExternoVM request);
        GeneralResponse EliminarLocalidad(int id);
    }
}
