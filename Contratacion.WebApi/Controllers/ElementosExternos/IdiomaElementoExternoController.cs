using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("IdiomaElemento")]
    [ApiController]
    [Authorize]
    public class IdiomaElementoExternoController : ControllerBase
    {
        private readonly IIdiomaElementoExternoService _idiomaElementoExterno;

        public IdiomaElementoExternoController(IIdiomaElementoExternoService idiomaElementoExterno)
        {
            _idiomaElementoExterno = idiomaElementoExterno;
        }

        [HttpPost("Listar")]
        public ActionResult<List<IdiomaElementoExternoVM>> Listar(IdRequest request)
        {
            return Ok(_idiomaElementoExterno.ListarIdiomas(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(IdiomaElementoExternoVM request)
        {
            return Ok(_idiomaElementoExterno.GuardarIdioma(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(IdiomaElementoExternoVM request)
        {
            return Ok(_idiomaElementoExterno.ActualizarIdioma(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_idiomaElementoExterno.EliminarIdioma(request.Id));
        }
    }
}
