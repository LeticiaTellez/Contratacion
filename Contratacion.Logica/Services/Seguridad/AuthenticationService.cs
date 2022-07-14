using Contratacion.Datos.Seguridad;
using Contratacion.Logica.Interfaces;
using Contratacion.Logica.Interfaces.Seguridad;
using Contratacion.Modelos;
using Contratacion.Modelos.Seguridad;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contratacion.Logica.Services.Seguridad
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public AuthenticationService(UserManager<Usuario> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<Usuario> signInManager,
            IEmailService emailService,
            IUserService userService)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _emailService = emailService;
            _userService = userService;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new AuthenticationResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El usuario '{request.UserName}' no existe." }
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return new AuthenticationResponse
                {
                    Status = false,
                    Errors = new List<string> { $"Las credenciales de {request.UserName} no son válidas." }
                };
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse
            {
                Status = true,
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                FullName = user.NombreCompleto,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed
            };

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(Usuario user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task<GeneralResponse> RegisterUserAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.UserName);

            if (existingUser != null)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El nombre de usuario '{request.UserName}' ya existe." }
                };
            }

            var user = new Usuario
            {
                Email = request.Email,
                NombreCompleto = request.FullName,
                UserName = request.UserName,
                UltimaActualizacionClave = DateTime.Now,
                EmailConfirmed = false
            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = result.Errors.Select(s => s.Description).ToList()
                    };
                }

                return await SendConfirmationEmailAsync(user.UserName);
            }
            else
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El correo { request.Email } ya existe." }
                };
            }
        }

        public async Task<GeneralResponse> ChangePasswordAsync(ChangePasswordRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El usuario '{request.UserName}' no existe." }
                };
            }

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (!result.Succeeded)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = result.Errors.Select(s => s.Description).ToList()
                };
            }

            return new GeneralResponse { Status = true };
        }

        public async Task<GeneralResponse> SendRecoveryEmailAsync(RecoveryEmailRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El correo '{request.Email}' no está asociado a un usuario o no se ha confirmado." }
                };
            }

            var param = await GetParametersRecoverEmail(user, request.Url);
            var result = await _emailService.SendEmail(request.Email, param.Subject, param.Body);

            if (!result.Status)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = result.Errors
                };
            }

            return new GeneralResponse { Status = true };
        }

        private async Task<EmailSettings> GetParametersRecoverEmail(Usuario user, string url)
        {
            var email = new EmailSettings();

            email.Token = await _userManager.GeneratePasswordResetTokenAsync(user);
            email.Subject = "Restablecer contraseña";
            email.Body = $"Para restablecer la contraseña, haga clic <a href=\"{url}?token={email.Token}&user={user.UserName}\" >aquí</a>";

            return email;
        }

        public async Task<GeneralResponse> RecoverPasswordAsync(RecoverPasswordRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El usuario '{request.UserName}' no existe." }
                };
            }

            var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

            if (!result.Succeeded)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = result.Errors.Select(s => s.Description).ToList()
                };
            }

            return new GeneralResponse { Status = true };
        }

        public async Task<GeneralResponse> SendConfirmationEmailAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"No se encontró el usuario {userName}" }
                };
            }

            var param = GetParametersConfirmationEmail();
            var result = await _emailService.SendEmail(user.Email, param.Subject, param.Body);

            if (!result.Status)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = result.Errors
                };
            }

            return _userService.SetCodeEmail(user, param.Token);
        }

        private EmailSettings GetParametersConfirmationEmail()
        {
            var email = new EmailSettings();
            var random = new Random();

            email.Token = random.Next(0, 1000000).ToString("D6");
            email.Subject = "Confirmación de Correo";
            email.Body = $"Ingrese el siguiente código en el sistema para confirmar su dirección de correo: <h2>{email.Token}</h2>";

            return email;
        }

        public async Task<GeneralResponse> UpdateEmailConfirmedAsync(EmailConfirmedRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"No se encontró el usuario {request.UserName}" }
                };
            }

            return _userService.UpdateEmailConfirmed(user, request.Code);
        }

        public async Task<GeneralResponse> ChangeEmailAsync(ChangeEmailRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { $"El usuario '{request.UserName}' no existe." }
                };
            }

            string token = await _userManager.GenerateChangeEmailTokenAsync(user, request.Email);
            var result = await _userManager.ChangeEmailAsync(user, request.Email, token);

            if (!result.Succeeded)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = result.Errors.Select(s => s.Description).ToList()
                };
            }

            return _userService.UpdateEmailUnconfirmed(user);
        }
    }
}
