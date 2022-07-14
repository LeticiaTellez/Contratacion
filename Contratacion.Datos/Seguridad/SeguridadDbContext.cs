using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contratacion.Datos.Seguridad
{
    public class SeguridadDbContext :
        IdentityDbContext<Usuario, Rol, long, ReclamacionUsuario, RolUsuarios, InicioSesionUsuario, ReclamacionRoles, TokenUsuario>
    {
        public DbSet<ParametrosConfiguracion> ParametrosConfiguracion { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public SeguridadDbContext(DbContextOptions<SeguridadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(SeguridadDbContext).Assembly);
        }
    }
}
