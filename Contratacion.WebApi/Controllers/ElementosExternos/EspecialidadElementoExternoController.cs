using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("EspecialidadElemento")]
    [ApiController]
    [Authorize]
    public class EspecialidadElementoExternoController : ControllerBase
    {
        private readonly IEspecialidadElementoExternoService _especialidadElementoExterno;

        public EspecialidadElementoExternoController(IEspecialidadElementoExternoService especialidadElementoExterno)
        {
            _especialidadElementoExterno = especialidadElementoExterno;
        }

        [HttpPost("Listar")]
        public ActionResult<List<EspecialidadElementoExternoVM>> Listar(IdRequest request)
        {
            return Ok(_especialidadElementoExterno.ListarEspecialidades(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(EspecialidadElementoExternoVM request)
        {
            return Ok(_especialidadElementoExterno.GuardarEspecialidad(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(EspecialidadElementoExternoVM request)
        {
            return Ok(_especialidadElementoExterno.ActualizarEspecialidad(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_especialidadElementoExterno.EliminarEspecialidad(request.Id));
        }
    }
}
