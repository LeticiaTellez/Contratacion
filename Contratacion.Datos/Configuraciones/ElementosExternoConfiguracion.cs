using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class ElementosExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<ElementosExterno> entity)
        {
            entity.ToTable("ElementosExternos", "contratacion");

            entity.HasIndex(e => e.Identificacion, "codigo");

            entity.HasIndex(e => e.Identificacion, "elementos_externos_uq")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("apellidos");

            entity.Property(e => e.AspiracionSalarial).HasColumnName("aspiracion_salarial");

            entity.Property(e => e.IdCargoAspirado).HasColumnName("id_cargo_aspirado");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("codigo");

            entity.Property(e => e.Contratado).HasColumnName("contratado");

            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("correo_electronico");

            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");

            entity.Property(e => e.IdEstadoCivil).HasColumnName("id_estado_civil");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");

            entity.Property(e => e.IdRegionActual).HasColumnName("id_region_actual");

            entity.Property(e => e.Identificacion)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("identificacion");

            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");

            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(150)
                .HasColumnName("nacionalidad");

            entity.Property(e => e.NoSeguroSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("no_seguro_social");

            entity.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombres");

            entity.Property(e => e.NumLicencia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("num_licencia");

            entity.Property(e => e.Sexo)
                .HasMaxLength(50)
                .HasColumnName("sexo");

            entity.Property(e => e.Telefono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.CargoAspirado)
                .WithMany(p => p.ElementosExternos)
                .HasForeignKey(d => d.IdCargoAspirado)
                .HasConstraintName("FKD082D503A56142C0");

            entity.HasOne(d => d.EstadoCivil)
                .WithMany(p => p.ElementosExternoEstadoCivil)
                .HasForeignKey(d => d.IdEstadoCivil)
                .HasConstraintName("FKD082D50318F887B6");

            entity.HasOne(d => d.RegionActual)
                .WithMany(p => p.ExternoRegionActual)
                .HasForeignKey(d => d.IdRegionActual)
                .HasConstraintName("FKD082D503889A34D8");
        }
    }
}
