using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class RolUsuariosConfiguracion : IEntityTypeConfiguration<RolUsuarios>
    {
        public void Configure(EntityTypeBuilder<RolUsuarios> builder)
        {
            builder.ToTable("RolesUsuarios", "seguridad");
            builder.Property(c => c.UserId).HasColumnName("IdUsuario");
            builder.Property(c => c.RoleId).HasColumnName("IdRol");
        }
    }
}
