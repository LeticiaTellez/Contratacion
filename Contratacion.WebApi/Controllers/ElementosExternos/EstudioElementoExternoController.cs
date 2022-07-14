using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("EstudioElemento")]
    [ApiController]
    [Authorize]
    public class EstudioElementoExternoController : ControllerBase
    {
        private readonly IEstudioElementoExternoService  _estudioElementoExterno;

        public EstudioElementoExternoController(IEstudioElementoExternoService estudioElementoExterno)
        {
            _estudioElementoExterno = estudioElementoExterno;
        }

        [HttpPost("Listar")]
        public ActionResult<List<EstudioElementoExternoVM>> Listar(IdRequest request)
        {
            return Ok(_estudioElementoExterno.ListarEstudios(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(EstudioElementoExternoVM request)
        {
            return Ok(_estudioElementoExterno.GuardarEstudio(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(EstudioElementoExternoVM request)
        {
            return Ok(_estudioElementoExterno.ActualizarEstudio(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_estudioElementoExterno.EliminarEstudio(request.Id));
        }
    }
}
