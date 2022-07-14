using Contratacion.Logica.Interfaces.Vacantes;
using Contratacion.Modelos.Vacantes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Contratacion.WebApi.Controllers.Vacantes
{
    [Route("Vacante")]
    [ApiController]
    public class VacanteController : ControllerBase
    {
        private readonly IVacanteService _vacanteService;

        public VacanteController(IVacanteService vacanteService)
        {
            _vacanteService = vacanteService;
        }

        [HttpGet("Listar")]
        public ActionResult<List<VacanteVM>> Listar()
        {
            return Ok(_vacanteService.ListarVacantes());
        }

        [HttpGet("ObtenerAreas")]
        public ActionResult<List<AreaResponse>> ListarAreas()
        {
            return Ok(_vacanteService.ListarAreas());
        }
    }
}
