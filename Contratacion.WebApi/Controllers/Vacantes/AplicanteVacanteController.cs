using Contratacion.Logica.Interfaces.Vacantes;
using Contratacion.Modelos;
using Contratacion.Modelos.Vacantes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contratacion.WebApi.Controllers.Vacantes
{
    [Route("AplicacionVacante")]
    [ApiController]
    [Authorize]
    public class AplicanteVacanteController : ControllerBase
    {
        private readonly IAplicanteVacanteService _aplicanteService;

        public AplicanteVacanteController(IAplicanteVacanteService aplicanteService)
        {
            _aplicanteService = aplicanteService;
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(AplicanteVacanteVM request)
        {
            return Ok(_aplicanteService.GuardarAplicacion(request));
        }
    }
}
