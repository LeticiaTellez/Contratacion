using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public abstract class BaseConfiguracion<T> : IEntityTypeConfiguration<T> where T : Base
    {
        public BaseConfiguracion()
        {
        }


        public virtual void Configure(EntityTypeBuilder<T> builder) 
        {
            builder.Property(e => e.Estado).HasColumnName("estado");
            builder.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");
            builder.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion");

        }
    }
}
