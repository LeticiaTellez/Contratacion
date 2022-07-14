using Contratacion.Logica.Interfaces.Seguridad;
using Contratacion.Modelos;
using Contratacion.Modelos.Seguridad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Contratacion.WebApi.Controllers
{
    [Route("Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        { 
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<GeneralResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterUserAsync(request));
        }

        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<ActionResult<GeneralResponse>> ChangePasswordAsync(ChangePasswordRequest request)
        {
            return Ok(await _authenticationService.ChangePasswordAsync(request));
        }

        [HttpPost("SendRecoveryEmail")]
        public async Task<ActionResult<GeneralResponse>> SendRecoveryEmailAsync(RecoveryEmailRequest request)
        {
            return Ok(await _authenticationService.SendRecoveryEmailAsync(request));
        }

        [HttpPost("RecoverPassword")]
        public async Task<ActionResult<GeneralResponse>> RecoverPasswordAsync(RecoverPasswordRequest request)
        {
            return Ok(await _authenticationService.RecoverPasswordAsync(request));
        }

        [HttpPost("SendConfirmationEmail")]
        public async Task<ActionResult<GeneralResponse>> SendConfirmationEmailAsync(UserNameRequest request)
        {
            return Ok(await _authenticationService.SendConfirmationEmailAsync(request.UserName));
        }

        [HttpPost("UpdateEmailConfirmed")]
        public async Task<ActionResult<GeneralResponse>> UpdateEmailConfirmedAsync(EmailConfirmedRequest request)
        {
            return Ok(await _authenticationService.UpdateEmailConfirmedAsync(request));
        }

        [HttpPost("ChangeEmail")]
        public async Task<ActionResult<GeneralResponse>> ChangeEmailAsync(ChangeEmailRequest request)
        {
            return Ok(await _authenticationService.ChangeEmailAsync(request));
        }
    }
}
