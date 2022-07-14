using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("ArchivoElemento")]
    [ApiController]
    [Authorize]
    public class ArchivoElementoExternoController : ControllerBase
    {
        private readonly IArchivoElementoExternoService _archivoElementoExterno;

        public ArchivoElementoExternoController(IArchivoElementoExternoService archivoElementoExterno)
        {
            _archivoElementoExterno = archivoElementoExterno;
        }

        [HttpPost("Listar")]
        public ActionResult<List<ArchivoElementoExternoVM>> Listar(IdRequest request)
        {
            return Ok(_archivoElementoExterno.ListarArchivos(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(ArchivoElementoExternoVM request)
        {
            return Ok(_archivoElementoExterno.GuardarArchivo(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_archivoElementoExterno.EliminarArchivo(request.Id));
        }
    }
}
