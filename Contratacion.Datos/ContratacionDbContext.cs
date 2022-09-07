using Contratacion.Datos.Configuraciones;
using Contratacion.Datos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contratacion.Datos
{
    public class ContratacionDbContext :
        IdentityDbContext<Usuario, Rol, long, ReclamacionUsuario, RolUsuarios, InicioSesionUsuario, ReclamacionRoles, TokenUsuario>
    {
        public DbSet<ParametrosConfiguracion> ParametrosConfiguracion { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AplicantesVacante> AplicantesVacante { get; set; }
        public DbSet<ArchivoExterno> ArchivosExterno { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<DocumentosRequerido> DocumentosRequerido { get; set; }
        public DbSet<ElementosExterno> ElementosExternos { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<EspecialidadExterno> EspecialidadExternos { get; set; }
        public DbSet<EstudiosExterno> EstudiosExternos { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<ExperienciaExterno> ExperienciaExternos { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<IdiomasExterno> IdiomasExternos { get; set; }
        public DbSet<MotivosDescarte> MotivosDescartes { get; set; }
        public DbSet<ReferenciasExterno> ReferenciasExterno { get; set; }
        public DbSet<Regiones> Regiones { get; set; }
        public DbSet<RequisicionPersonal> RequisicionPersonal { get; set; }
        public DbSet<TiposEmpleado> TiposEmpleados { get; set; }
        public DbSet<UsuariosExterno> UsuariosExterno { get; set; }
        public DbSet<Vacantes> Vacantes { get; set; }

        public ContratacionDbContext(DbContextOptions<ContratacionDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ContratacionDbContext).Assembly);
        }
    }
}
