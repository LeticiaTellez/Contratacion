using Contratacion.Datos.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class RolesConfiguracion : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Roles", "seguridad");
            builder.Property(c => c.Id).HasColumnName("IdRol");
            builder.Property(c => c.Name).HasColumnName("NombreRol").IsRequired();
            builder.Property(c => c.NormalizedName).HasColumnName("NombreRolNormalizado");
            builder.Property(c => c.ConcurrencyStamp).HasColumnName("MomentoConcurrencia");
        }
    }
}
