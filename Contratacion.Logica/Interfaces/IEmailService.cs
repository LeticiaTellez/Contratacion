using Contratacion.Modelos;
using System.Threading.Tasks;

namespace Contratacion.Logica.Interfaces
{
    public interface IEmailService
    {
        Task<GeneralResponse> SendEmail(string to, string subject, string html);
    }
}
