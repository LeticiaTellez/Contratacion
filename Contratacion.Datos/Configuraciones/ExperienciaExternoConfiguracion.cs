using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Contratacion.Datos.Configuraciones
{
    public class ExperienciaExternoConfiguracion
    {
        public void Configure(EntityTypeBuilder<ExperienciaExterno> entity)
        {
            entity.ToTable("ExperienciaExterno", "contratacion");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.CagoJefe)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cago_jefe");

            entity.Property(e => e.CargoDesempenado)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cargo_desempenado");

            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");

            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");

            entity.Property(e => e.FichaLaboral)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ficha_laboral");

            entity.Property(e => e.IdExterno).HasColumnName("id_externo");

            entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

            entity.Property(e => e.MotivoRetiro)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("motivo_retiro");

            entity.Property(e => e.NombreJefe)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre_jefe");

            entity.Property(e => e.SueldoMensual).HasColumnName("sueldo_mensual");

            entity.HasOne(d => d.Externo)
                .WithMany(p => p.ExperienciaExternos)
                .HasForeignKey(d => d.IdExterno)
                .HasConstraintName("experiencia_externo_elemento_fk");

            entity.HasOne(d => d.Empresa)
                .WithMany(p => p.ExperienciaExternos)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("experiencia_externo_empresa_fk");
        }
    }
}
