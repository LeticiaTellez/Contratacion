using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class ReclamacionRolesConfiguracion : IEntityTypeConfiguration<ReclamacionRoles>
    {
        public void Configure(EntityTypeBuilder<ReclamacionRoles> builder)
        {
            builder.ToTable("ReclamacionRoles", "seguridad");
            builder.Property(c => c.RoleId).HasColumnName("IdRol");
            builder.Property(c => c.ClaimType).HasColumnName("TipoReclamacion");
            builder.Property(c => c.ClaimValue).HasColumnName("ValorReclamacion");
        }
    }
}
