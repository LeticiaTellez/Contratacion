using Microsoft.AspNetCore.Identity;
using System;

namespace Contratacion.Datos.Models
{
    public class Usuario : IdentityUser<long>
    {
        public string NombreCompleto { get; set; }
        public string CodigoConfirmacionCorreo { get; set; }
        public DateTime? FechaEnvioCodigo { get; set; }
        public virtual DateTime UltimaActualizacionClave { get; set; }
    }

    public class RolUsuarios : IdentityUserRole<long>
    {
        public int IdEmpresa { get; set; }
    }

    public class Rol : IdentityRole<long> { }
    public class InicioSesionUsuario : IdentityUserLogin<long> { }
    public class ReclamacionUsuario : IdentityUserClaim<long> { }
    public class ReclamacionRoles : IdentityRoleClaim<long> { }
    public class TokenUsuario : IdentityUserToken<long> { }

    public class ParametrosConfiguracion
    {
        public int IdParametro { get; set; }
        public string NombreParametro { get; set; }
        public string Alias { get; set; }
        public float? ValorNumerico { get; set; }
        public DateTime? ValorFecha { get; set; }
        public string ValorTexto { get; set; }
        public string NombreCategoria { get; set; }
        public bool Estado { get; set; }
    }
}
