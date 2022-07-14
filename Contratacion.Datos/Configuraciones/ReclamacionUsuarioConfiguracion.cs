using Contratacion.Datos.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class ReclamacionUsuarioConfiguracion : IEntityTypeConfiguration<ReclamacionUsuario>
    {
        public void Configure(EntityTypeBuilder<ReclamacionUsuario> builder)
        {
            builder.ToTable("ReclamacionesUsuario", "seguridad");
            builder.Property(c => c.UserId).HasColumnName("IdUsuario");
            builder.Property(c => c.ClaimType).HasColumnName("TipoReclamacion");
            builder.Property(c => c.ClaimValue).HasColumnName("ValorReclamacion");
        }
    }
}
