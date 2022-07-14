using Contratacion.Datos.Seguridad;
using Contratacion.Modelos;

namespace Contratacion.Logica.Interfaces.Seguridad
{
    public interface IUserService
    {
        long GetIdUser(string userName);
        GeneralResponse SetCodeEmail(Usuario user, string code);
        GeneralResponse UpdateEmailConfirmed(Usuario user, string code);
        GeneralResponse UpdateEmailUnconfirmed(Usuario user);
    }
}
