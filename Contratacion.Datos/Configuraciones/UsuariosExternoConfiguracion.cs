using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class UsuariosExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<UsuariosExterno> entity)
        {
            entity.ToTable("UsuariosExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.ElementoExterno)
                .WithMany(p => p.UsuariosExternos)
                .HasForeignKey(d => d.IdExterno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuarios_elemento_externo_fk");
        }
    }
}
