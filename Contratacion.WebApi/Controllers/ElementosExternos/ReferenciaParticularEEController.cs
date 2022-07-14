using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("ReferenciaParticular")]
    [ApiController]
    [Authorize]
    public class ReferenciaParticularEEController : ControllerBase
    {
        private readonly IReferenciaParticularEEService _referenciaParticularEE;

        public ReferenciaParticularEEController(IReferenciaParticularEEService referenciaParticularEE)
        {
            _referenciaParticularEE = referenciaParticularEE;
        }

        [HttpPost("Listar")]
        public ActionResult<List<ReferenciaParticularEEVM>> Listar(IdRequest request)
        {
            return Ok(_referenciaParticularEE.ListarRerenciasParticulares(request.Id));
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(ReferenciaParticularEEVM request)
        {
            return Ok(_referenciaParticularEE.GuardarReferenciaParticular(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(ReferenciaParticularEEVM request)
        {
            return Ok(_referenciaParticularEE.ActualizarReferenciaParticular(request));
        }

        [HttpPost("Eliminar")]
        public ActionResult<GeneralResponse> Eliminar(IdRequest request)
        {
            return Ok(_referenciaParticularEE.EliminarReferenciaParticular(request.Id));
        }
    }
}
