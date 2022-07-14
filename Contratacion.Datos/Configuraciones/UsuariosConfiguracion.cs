using Contratacion.Datos.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    class UsuariosConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "seguridad");
            builder.Property(u => u.Id).HasColumnName("IdUsuario");
            builder.Property(u => u.Email).HasColumnName("Correo");
            builder.Property(u => u.EmailConfirmed).HasColumnName("CorreoConfirmado");
            builder.Property(u => u.NormalizedEmail).HasColumnName("CorreoNormalizado");
            builder.Property(u => u.PasswordHash).HasColumnName("ClaveHash");
            builder.Property(u => u.SecurityStamp).HasColumnName("SelloSeguridad");
            builder.Property(u => u.PhoneNumber).HasColumnName("Telefono");
            builder.Property(u => u.PhoneNumberConfirmed).HasColumnName("TelefonoConfirmado");
            builder.Property(u => u.TwoFactorEnabled).HasColumnName("DosFactores");
            builder.Property(u => u.LockoutEnd).HasColumnName("BloquearHasta");
            builder.Property(u => u.LockoutEnabled).HasColumnName("HabilitarBloquedo");
            builder.Property(u => u.AccessFailedCount).HasColumnName("CantidadErroresAcceso");
            builder.Property(u => u.UserName).HasColumnName("Usuario").IsRequired();
            builder.Property(u => u.NormalizedUserName).HasColumnName("UsuarioNormalizado");
            builder.Property(u => u.NombreCompleto).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(u => u.UltimaActualizacionClave).HasColumnType("datetime");
            builder.Property(u => u.CodigoConfirmacionCorreo).HasColumnType("nvarchar(20)");
            builder.Property(u => u.FechaEnvioCodigo).HasColumnType("datetime");
        }
    }
}
