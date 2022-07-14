using Contratacion.Datos.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class InicioSesionUsuariosConfiguracion : IEntityTypeConfiguration<InicioSesionUsuario>
    {
        public void Configure(EntityTypeBuilder<InicioSesionUsuario> builder)
        {
            builder.ToTable("InicioSesionUsuarios", "seguridad");
            builder.Property(c => c.LoginProvider).HasColumnName("InicioSesionProvedor");
            builder.Property(c => c.ProviderKey).HasColumnName("ClaveProveedor");
            builder.Property(c => c.UserId).HasColumnName("IdUsuario");
            builder.Property(c => c.ProviderDisplayName).HasColumnName("NombreProveedor");
        }
    }
}
