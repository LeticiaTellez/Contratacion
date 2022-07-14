using Contratacion.Modelos;
using System.Collections.Generic;

namespace Contratacion.Logica.Interfaces
{
    public interface IDropDownService
    {
        public List<DropDownResponse> cmbObtenerCatalogos(int idPadre);
        public List<DropDownResponse> cmbObtenerRegiones();
        public List<DropDownResponse> cmbObtenerCargos();
        public List<DropDownResponse> cmbObtenerEspecialidades();
        public List<DropDownResponse> cmbObtenerIdiomas();
        public List<DropDownResponse> cmbObtenerTiposDocumento();
    }
}
