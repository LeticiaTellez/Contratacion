using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;

namespace Contratacion.Logica.Interfaces.ElementosExternos
{
    public interface IElementoExternoService
    {
        GeneralResponse GuardarElementoExterno(ElementoExternoRequest request);
        GeneralResponse ActualizarElementoExterno(ElementoExternoRequest request);
        ElementoExternoResponse DetallarElementoExterno(int Id);
        int FindEExternoUsuario(int idUsuario);
    }
}
