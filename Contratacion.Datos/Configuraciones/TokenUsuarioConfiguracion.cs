using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class TokenUsuarioConfiguracion : IEntityTypeConfiguration<TokenUsuario>
    {
        public void Configure(EntityTypeBuilder<TokenUsuario> builder)
        {
            builder.ToTable("TokenUsuario", "seguridad");
            builder.Property(c => c.UserId).HasColumnName("IdUsuario");
            builder.Property(c => c.Name).HasColumnName("Nombre");
            builder.Property(c => c.Value).HasColumnName("Valor");
            builder.Property(c => c.LoginProvider).HasColumnName("InicioSesionProveedor");
        }
    }
}
