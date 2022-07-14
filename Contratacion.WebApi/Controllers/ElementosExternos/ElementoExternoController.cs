using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Logica.Interfaces.Seguridad;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contratacion.WebApi.Controllers.ElementosExternos
{
    [Route("ElementoExterno")]
    [ApiController]
    [Authorize]
    public class ElementoExternoController : ControllerBase
    {
        private readonly IElementoExternoService _elementoExternoService;
        private readonly IUserService _userService;
        
        public ElementoExternoController(IElementoExternoService elementoExternoService,
            IUserService userService)
        {
            _elementoExternoService = elementoExternoService;
            _userService = userService;
        }

        [HttpPost("Guardar")]
        public ActionResult<GeneralResponse> Guardar(ElementoExternoRequest request)
        {
            request.IdUsuario = (int)_userService.GetIdUser(UserName());
            request.CorreoElectronico = User.FindFirstValue(ClaimTypes.Email);

            return Ok(_elementoExternoService.GuardarElementoExterno(request));
        }

        [HttpPost("Actualizar")]
        public ActionResult<GeneralResponse> Actualizar(ElementoExternoRequest request)
        {
            request.CorreoElectronico = User.FindFirstValue(ClaimTypes.Email);

            return Ok(_elementoExternoService.ActualizarElementoExterno(request));
        }

        [HttpGet("Detallar")]
        public ActionResult<ElementoExternoResponse> ObtenerDetalle()
        {
            int IdUsuario = (int)_userService.GetIdUser(UserName());
            int id = _elementoExternoService.FindEExternoUsuario(IdUsuario);

            return Ok(_elementoExternoService.DetallarElementoExterno(id));
        }

        [HttpGet("ObtenerId")]
        public ActionResult<int> ObtenerIdElementoExterno()
        {
            int IdUsuario = (int)_userService.GetIdUser(UserName());

            return Ok(_elementoExternoService.FindEExternoUsuario(IdUsuario));
        }

        string UserName() 
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
