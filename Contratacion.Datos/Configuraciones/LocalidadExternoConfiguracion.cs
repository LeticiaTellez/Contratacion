using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class LocalidadExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<LocalidadExterno> entity)
        {
            entity.ToTable("LocalidadExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.EstaActivo).HasColumnName("esta_activo");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

            entity.Property(e => e.IdElementoExterno).HasColumnName("id_elemento_externo");

            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

            entity.Property(e => e.IdPais).HasColumnName("id_pais");

            entity.HasOne(d => d.Departamento)
                .WithMany(p => p.LocalidadExternoIdDepartamento)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK846CAA996EA46284");

            entity.HasOne(d => d.ElementoExterno)
                .WithMany(p => p.LocalidadElementoExternos)
                .HasForeignKey(d => d.IdElementoExterno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK846CAA992E182ACA");

            entity.HasOne(d => d.Municipio)
                .WithMany(p => p.LocalidadExternoIdMunicipio)
                .HasForeignKey(d => d.IdMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK846CAA9929A5AFA5");

            entity.HasOne(d => d.Pais)
                .WithMany(p => p.LocalidadElementoExternoIdPais)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK846CAA9984E87D5B");
        }
    }
}
