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

            entity.Property(e => e.EstadoCivil).HasColumnName("estado_civil");

            entity.Property(e => e.Estatura).HasColumnName("estatura");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nacimiento");

            entity.Property(e => e.IdRegionActual).HasColumnName("id_region_actual");

            entity.Property(e => e.IdRegionNatal).HasColumnName("id_region_natal");

            entity.Property(e => e.Identificacion)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("identificacion");

            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("imagen");

            entity.Property(e => e.IdLicenciaConducir).HasColumnName("licencia_conducir");

            entity.Property(e => e.Nacionalidad).HasColumnName("nacionalidad");

            entity.Property(e => e.NoPasaporte)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("no_pasaporte");

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

            entity.Property(e => e.Peso).HasColumnName("peso");

            entity.Property(e => e.IdSexo).HasColumnName("sexo");

            entity.Property(e => e.Telefono1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono1");

            entity.Property(e => e.Telefono2)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("telefono2");

            entity.Property(e => e.IdTipoSangre).HasColumnName("tipo_sangre");

            entity.Property(e => e.IdUnidadEstatura).HasColumnName("unidad_estatura");

            entity.Property(e => e.IdUnidadPeso).HasColumnName("unidad_peso");

            entity.HasOne(d => d.CargoAspirado)
                .WithMany(p => p.ElementosExternos)
                .HasForeignKey(d => d.IdCargoAspirado)
                .HasConstraintName("FKD082D503A56142C0");

            entity.HasOne(d => d.EstadoCivil)
                .WithMany(p => p.ElementosExternoEstadoCivil)
                .HasForeignKey(d => d.EstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKD082D50318F887B6");

            entity.HasOne(d => d.RegionActual)
                .WithMany(p => p.ExternoRegionActual)
                .HasForeignKey(d => d.IdRegionActual)
                .HasConstraintName("FKD082D503889A34D8");

            entity.HasOne(d => d.RegionNatal)
                .WithMany(p => p.ExternoRegionNatal)
                .HasForeignKey(d => d.IdRegionNatal)
                .HasConstraintName("FKD082D503D1409068");

            entity.HasOne(d => d.LicenciaConducir)
                .WithMany(p => p.ElementosExternoLicenciaConducir)
                .HasForeignKey(d => d.IdLicenciaConducir)
                .HasConstraintName("FKD082D5038599DE68");

            entity.HasOne(d => d.Nacionalidad)
                .WithMany(p => p.ElementosExternoNacionalidad)
                .HasForeignKey(d => d.Nacionalidad)
                .HasConstraintName("FKD082D5039514ADFD");

            entity.HasOne(d => d.Sexo)
                .WithMany(p => p.ElementosExternoSexo)
                .HasForeignKey(d => d.IdSexo)
                .HasConstraintName("FKD082D503229C46A5");

            entity.HasOne(d => d.TipoSangre)
                .WithMany(p => p.ElementosExternoTipoSangre)
                .HasForeignKey(d => d.IdTipoSangre)
                .HasConstraintName("FKD082D5031FF1A641");

            entity.HasOne(d => d.UnidadEstatura)
                .WithMany(p => p.ElementosExternoUnidadEstatura)
                .HasForeignKey(d => d.IdUnidadEstatura)
                .HasConstraintName("FKD082D5037D9CEB0F");

            entity.HasOne(d => d.UnidadPeso)
                .WithMany(p => p.ElementosExternoUnidadPeso)
                .HasForeignKey(d => d.IdUnidadPeso)
                .HasConstraintName("FKD082D50345D20F95");
        }
    }
}
