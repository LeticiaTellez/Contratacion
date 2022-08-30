using Contratacion.Datos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contratacion.Datos.Configuraciones
{
    public class CargoConfiguracion : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> entity)
        {
            entity.ToTable("Cargos", "contratacion");

            entity.HasIndex(e => e.Id, "UQ_cargo_id")
                .IsUnique();

            entity.HasIndex(e => e.Codigo, "cargos_uq")
                .IsUnique();

            entity.HasIndex(e => e.Codigo, "codigo");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Activo).HasColumnName("activo");

            entity.Property(e => e.Codigo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("codigo");

            entity.Property(e => e.DescripcionGenerica)
                .IsUnicode(false)
                .HasColumnName("descripcion_generica");

            entity.Property(e => e.Estado).HasColumnName("estado");

            entity.Property(e => e.FechaElaboracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_elaboracion");

            entity.Property(e => e.IdCategoriaCargo).HasColumnName("id_categoria_cargo");

            entity.Property(e => e.IdGrupoEscala).HasColumnName("id_grupo_escala");

            entity.Property(e => e.IdNivelEscolaridad).HasColumnName("id_nivel_escolaridad");

            entity.Property(e => e.IdPadre).HasColumnName("id_padre");

            entity.Property(e => e.IdSolicitante).HasColumnName("Id_solicitante");

            entity.Property(e => e.IdTipoFuncionario).HasColumnName("id_tipo_funcionario");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.Property(e => e.Observaciones)
                .IsUnicode(false)
                .HasColumnName("observaciones");

            entity.Property(e => e.SalarioBase).HasColumnName("salario_base");

            entity.Property(e => e.SalarioHasta).HasColumnName("salario_hasta");

            entity.HasOne(d => d.CategoriaCargo)
                .WithMany(p => p.CargoIdCategoriaCargo)
                .HasForeignKey(d => d.IdCategoriaCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAE7C103793BB7C68");

            entity.HasOne(d => d.NivelEscolaridad)
                .WithMany(p => p.CargoIdNivelEscolaridad)
                .HasForeignKey(d => d.IdNivelEscolaridad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAE7C1037759105BC");

            entity.HasOne(d => d.TipoFuncionario)
                .WithMany(p => p.CargoIdTipoFuncionario)
                .HasForeignKey(d => d.IdTipoFuncionario)
                .HasConstraintName("FKAE7C1037AD69E5D0");

        }
    }
}
