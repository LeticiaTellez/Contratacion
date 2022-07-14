using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("LocalidadElemento")]
    [ApiController]
    [Authorize]
    public class LocalidadElementoExternoController : ControllerBase
    {
        private readonly ILocalidadElementoExternoService _localidadElementoExterno;

        public LocalidadElementoExternoController(ILocalidadElementoExternoService localidadElementoExterno)
        {
            _localidadElementoExterno = localidadElementoExterno;
        }

        [HttpPost("Listar")]
        public ActionResult<List<LocalidadElementoExternoVM>> Listar(IdRequest request)
        {
            return Ok(_localidadElementoExterno.ListarLocalidades(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(LocalidadElementoExternoVM request)
        {
            return Ok(_localidadElementoExterno.GuardarLocalidad(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(LocalidadElementoExternoVM request)
        {
            return Ok(_localidadElementoExterno.ActualizarLocalidad(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_localidadElementoExterno.EliminarLocalidad(request.Id));
        }
    }
}
