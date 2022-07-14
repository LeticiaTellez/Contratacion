using Contratacion.Modelos;
using Contratacion.Modelos.Seguridad;
using System.Threading.Tasks;

namespace Contratacion.Logica.Interfaces.Seguridad
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<GeneralResponse> RegisterUserAsync(RegistrationRequest request);
        Task<GeneralResponse> ChangePasswordAsync(ChangePasswordRequest request);
        Task<GeneralResponse> SendRecoveryEmailAsync(RecoveryEmailRequest request);
        Task<GeneralResponse> RecoverPasswordAsync(RecoverPasswordRequest request);
        Task<GeneralResponse> SendConfirmationEmailAsync(string userName);
        Task<GeneralResponse> UpdateEmailConfirmedAsync(EmailConfirmedRequest request);
        Task<GeneralResponse> ChangeEmailAsync(ChangeEmailRequest request);
    }
}
