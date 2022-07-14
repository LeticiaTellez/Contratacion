using Contratacion.Datos.Models;
using Contratacion.Logica.Interfaces;
using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Logica.Interfaces.Seguridad;
using Contratacion.Logica.Interfaces.Vacantes;
using Contratacion.Logica.Services;
using Contratacion.Logica.Services.ElementosExternos;
using Contratacion.Logica.Services.Seguridad;
using Contratacion.Logica.Services.Vacantes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contratacion.Logica.Extensiones
{
    public static class ContratacionExtensions
    {
        public static void AddContratacionServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContratacionDbContext>(options => options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("ContratacionConnectionString"),
                b => b.MigrationsAssembly(typeof(ContratacionDbContext).Assembly.FullName)));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IElementoExternoService, ElementoExternoService>();
            services.AddTransient<IExperienciaElementoExternoService, ExperienciaElementoExternoService>();
            services.AddTransient<IEstudioElementoExternoService, EstudioElementoExternoService>();
            services.AddTransient<IEspecialidadElementoExternoService, EspecialidadElementoExternoService>();
            services.AddTransient<IReferenciaParticularEEService, ReferenciaParticularEEService>();
            services.AddTransient<ILocalidadElementoExternoService, LocalidadElementoExternoService>();
            services.AddTransient<IIdiomaElementoExternoService, IdiomaElementoExternoService>();
            services.AddTransient<IArchivoElementoExternoService, ArchivoElementoExternoService>();
            services.AddTransient<IVacanteService, VacanteService>();
            services.AddTransient<IAplicanteVacanteService, AplicanteVacanteService>();
            services.AddTransient<IDropDownService, DropDownService>();
        }
    }
}
