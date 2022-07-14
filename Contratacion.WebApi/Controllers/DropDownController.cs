using Contratacion.Logica.Interfaces;
using Contratacion.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contratacion.WebApi.Controllers
{
    [Route("DropDown")]
    [ApiController]
    [Authorize]
    public class DropDownController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;

        public DropDownController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        [HttpGet("ObtenerGenero")]
        public ActionResult<DropDownResponse> ObtenerGenero()
        {
            int genero = 10;
            return Ok(_dropDownService.cmbObtenerCatalogos(genero));
        }

        [HttpGet("ObtenerEstadoCivil")]
        public ActionResult<DropDownResponse> ObtenerEstadoCivil()
        {
            int estadoCivil = 1;
            return Ok(_dropDownService.cmbObtenerCatalogos(estadoCivil));
        }

        [HttpGet("ObtenerNacionalidad")]
        public ActionResult<DropDownResponse> ObtenerNacionalidad()
        {
            int nacionalidad = 54;
            return Ok(_dropDownService.cmbObtenerCatalogos(nacionalidad));
        }

        [HttpGet("ObtenerUnidadEstatura")]
        public ActionResult<DropDownResponse> ObtenerUnidadEstatura()
        {
            int unidadEstatura = 75;
            return Ok(_dropDownService.cmbObtenerCatalogos(unidadEstatura));
        }

        [HttpGet("ObtenerUnidadPeso")]
        public ActionResult<DropDownResponse> ObtenerUnidadPeso()
        {
            int unidadPeso = 72;
            return Ok(_dropDownService.cmbObtenerCatalogos(unidadPeso));
        }

        [HttpGet("ObtenerTipoSangre")]
        public ActionResult<DropDownResponse> ObtenerTipoSangre()
        {
            int tipoSangre = 47;
            return Ok(_dropDownService.cmbObtenerCatalogos(tipoSangre));
        }

        [HttpGet("ObtenerTipoLicencia")]
        public ActionResult<DropDownResponse> ObtenerTipoLicencia()
        {
            int tipoLicencia = 58;
            return Ok(_dropDownService.cmbObtenerCatalogos(tipoLicencia));
        }

        [HttpGet("ObtenerRegiones")]
        public ActionResult<DropDownResponse> ObtenerRegiones()
        {
            return Ok(_dropDownService.cmbObtenerRegiones());
        }

        [HttpGet("ObtenerCargos")]
        public ActionResult<DropDownResponse> ObtenerCargos()
        {
            return Ok(_dropDownService.cmbObtenerCargos());
        }

        [HttpGet("ObtenerNivelEstudios")]
        public ActionResult<DropDownResponse> ObtenerNivelEstudios()
        {
            int nivel = 12;
            return Ok(_dropDownService.cmbObtenerCatalogos(nivel));
        }

        [HttpGet("ObtenerInstituciones")]
        public ActionResult<DropDownResponse> ObtenerInstituciones()
        {
            int institucion = 62;
            return Ok(_dropDownService.cmbObtenerCatalogos(institucion));
        }

        [HttpGet("ObtenerEmpresas")]
        public ActionResult<DropDownResponse> ObtenerEmpresas()
        {
            int empresa = 27;
            return Ok(_dropDownService.cmbObtenerCatalogos(empresa));
        }

        [HttpGet("ObtenerEspecialidades")]
        public ActionResult<DropDownResponse> ObtenerEspecialidades()
        {
            return Ok(_dropDownService.cmbObtenerEspecialidades());
        }

        [HttpGet("ObtenerPaises")]
        public ActionResult<DropDownResponse> ObtenerPaises()
        {
            int pais = 445;
            return Ok(_dropDownService.cmbObtenerCatalogos(pais));
        }

        [HttpGet("ObtenerDepartamentos")]
        public ActionResult<DropDownResponse> ObtenerDepartamentos()
        {
            int pais = 446;
            return Ok(_dropDownService.cmbObtenerCatalogos(pais));
        }

        [HttpGet("ObtenerMunicipios")]
        public ActionResult<DropDownResponse> ObtenerMunicipios()
        {
            int pais = 447;
            return Ok(_dropDownService.cmbObtenerCatalogos(pais));
        }

        [HttpGet("ObtenerIdiomas")]
        public ActionResult<DropDownResponse> ObtenerIdiomas()
        {
            return Ok(_dropDownService.cmbObtenerIdiomas());
        }

        [HttpGet("ObtenerCalificaciones")]
        public ActionResult<DropDownResponse> ObtenerCalificaciones()
        {
            int calif = 29;
            return Ok(_dropDownService.cmbObtenerCatalogos(calif));
        }

        [HttpGet("ObtenerTipoReferencia")]
        public ActionResult<DropDownResponse> ObtenerTipoReferencia()
        {
            int tref = 68;
            return Ok(_dropDownService.cmbObtenerCatalogos(tref));
        }

        [HttpGet("ObtenerRelacion")]
        public ActionResult<DropDownResponse> ObtenerRelacion()
        {
            int relacion = 65;
            return Ok(_dropDownService.cmbObtenerCatalogos(relacion));
        }

        [HttpGet("ObtenerTiposDocumento")]
        public ActionResult<DropDownResponse> ObtenerTiposDocumento()
        {
            return Ok(_dropDownService.cmbObtenerTiposDocumento());
        }
    }
}
