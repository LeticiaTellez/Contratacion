using Contratacion.Logica.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using System.Linq;
using Contratacion.Modelos;
using System.Threading.Tasks;
using System.Collections.Generic;
using Contratacion.Datos;

namespace Contratacion.Logica.Services
{
    public class EmailService : IEmailService
    {
        private readonly ContratacionDbContext _dbContext;

        public EmailService(ContratacionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GeneralResponse> SendEmail(string to, string subject, string html)
        {
            try
            {
                var settings = GetEmailSettings();

                // create message
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(settings.From));
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = html };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(settings.Host, settings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(settings.From, settings.Pass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return new GeneralResponse { Status = true };
            }
            catch (System.Exception ex)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        private EmailSettings GetEmailSettings()
        {
            var settings = new EmailSettings();

            var parametros = _dbContext.ParametrosConfiguracion.Where(w => w.NombreCategoria == "CORREO" && w.Estado);
            settings.From = parametros.Where(w => w.Alias == "FROM").FirstOrDefault().ValorTexto;
            settings.Host = parametros.Where(w => w.Alias == "SMTP_HOST").FirstOrDefault().ValorTexto;
            settings.Port = (int)parametros.Where(w => w.Alias == "SMTP_PORT").FirstOrDefault().ValorNumerico;
            settings.Pass = parametros.Where(w => w.Alias == "SMTP_PASS").FirstOrDefault().ValorTexto;

            return settings;
        }
    }
}
