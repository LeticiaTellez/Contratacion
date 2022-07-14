using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IArchivoElementoExternoService
    {
        List<ArchivoElementoExternoVM> ListarArchivos(int idEexterno);
        GeneralResponse GuardarArchivo(ArchivoElementoExternoVM request);
        GeneralResponse EliminarArchivo(int id);
    }
}
