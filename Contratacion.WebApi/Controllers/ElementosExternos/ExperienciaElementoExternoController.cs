using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("ExperienciaElemento")]
    [ApiController]
    [Authorize]
    public class ExperienciaElementoExternoController : ControllerBase
    {
        private readonly IExperienciaElementoExternoService _experienciaElementoExterno;

        public ExperienciaElementoExternoController(IExperienciaElementoExternoService experienciaElementoExterno)
        {
            _experienciaElementoExterno = experienciaElementoExterno;
        }

        [HttpPost("Listar")]
        public ActionResult<List<ExperienciaElementoExternoVM>> Listar(IdRequest request)
        {
            return Ok(_experienciaElementoExterno.ListarExperiencias(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(ExperienciaElementoExternoVM request)
        {
            return Ok(_experienciaElementoExterno.GuardarExperiencia(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(ExperienciaElementoExternoVM request)
        {
            return Ok(_experienciaElementoExterno.ActualizarExperiencia(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_experienciaElementoExterno.EliminarExperiencia(request.Id));
        }
    }
}
