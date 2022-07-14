using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IReferenciaParticularEEService
    {
        List<ReferenciaParticularEEVM> ListarRerenciasParticulares(int idEexterno);
        GeneralResponse GuardarReferenciaParticular(ReferenciaParticularEEVM request);
        GeneralResponse ActualizarReferenciaParticular(ReferenciaParticularEEVM request);
        GeneralResponse EliminarReferenciaParticular(int id);
    }
}
