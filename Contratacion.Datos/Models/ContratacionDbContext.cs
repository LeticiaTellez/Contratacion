using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Contratacion.Datos.Models
{
    public partial class ContratacionDbContext : DbContext
    {
        public ContratacionDbContext()
        {
        }

        public ContratacionDbContext(DbContextOptions<ContratacionDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AplicantesVacante> AplicantesVacantes { get; set; }
        public virtual DbSet<ArchivoXExterno> ArchivoXExternos { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Catalogo> Catalogos { get; set; }
        public virtual DbSet<CatalogosDocumentosRequerido> CatalogosDocumentosRequeridos { get; set; }
        public virtual DbSet<ElementosExterno> ElementosExternos { get; set; }
        public virtual DbSet<Especialidad> Especialidads { get; set; }
        public virtual DbSet<EspecialidadXEexterno> EspecialidadXEexternos { get; set; }
        public virtual DbSet<EstudiosXEexterno> EstudiosXEexternos { get; set; }
        public virtual DbSet<ExpedienteTmp> ExpedienteTmps { get; set; }
        public virtual DbSet<ExperienciaXEexterno> ExperienciaXEexternos { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<IdiomasXEexterno> IdiomasXEexternos { get; set; }
        public virtual DbSet<LocalidadElementoExterno> LocalidadElementoExternos { get; set; }
        public virtual DbSet<MotivosDescarte> MotivosDescartes { get; set; }
        public virtual DbSet<ReferenciaParticularesEexterno> ReferenciaParticularesEexternos { get; set; }
        public virtual DbSet<Region> Regiones { get; set; }
        public virtual DbSet<RequisicionPersonal> RequisicionPersonals { get; set; }
        public virtual DbSet<TiposEmpleado> TiposEmpleados { get; set; }
        public virtual DbSet<UsuariosXEexterno> UsuariosXEexternos { get; set; }
        public virtual DbSet<Vacante> Vacantes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CS_AS");

            modelBuilder.Entity<AplicantesVacante>(entity =>
            {
                entity.ToTable("aplicantes_vacante", "seleccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AceptacionTerminos).HasColumnName("aceptacion_terminos");

                entity.Property(e => e.AspiracionSalarial).HasColumnName("aspiracion_salarial");

                entity.Property(e => e.CalificaEntrevista).HasColumnName("califica_entrevista");

                entity.Property(e => e.ComentariosAplicante).HasColumnName("comentarios_aplicante");

                entity.Property(e => e.ComentariosPrechequeo).HasColumnName("comentarios_prechequeo");

                entity.Property(e => e.EsDescartado).HasColumnName("es_descartado");

                entity.Property(e => e.EsPrechequeado).HasColumnName("es_prechequeado");

                entity.Property(e => e.EstadoAplicacion).HasColumnName("estado_aplicacion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaDescarte)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_descarte");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion");

                entity.Property(e => e.FechaPrechequeo)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_prechequeo");

                entity.Property(e => e.FormatoPrechequeo).HasColumnName("formato_prechequeo");

                entity.Property(e => e.IdCandidato).HasColumnName("id_candidato");

                entity.Property(e => e.IdMotivoDescarte).HasColumnName("id_motivo_descarte");

                entity.Property(e => e.IdVacante).HasColumnName("id_vacante");

                entity.HasOne(d => d.IdMotivoDescarteNavigation)
                    .WithMany(p => p.AplicantesVacantes)
                    .HasForeignKey(d => d.IdMotivoDescarte)
                    .HasConstraintName("FK__aplicante__id_mo__74DB9F4A");

                entity.HasOne(d => d.IdVacanteNavigation)
                    .WithMany(p => p.AplicantesVacantes)
                    .HasForeignKey(d => d.IdVacante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__aplicante__id_va__73E77B11");
            });

            modelBuilder.Entity<ArchivoXExterno>(entity =>
            {
                entity.ToTable("archivo_x_externo", "contratacion");

                entity.HasIndex(e => new { e.IdTipoDocumento, e.IdExpediente }, "id_foranero");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaRecepcion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_recepcion");

                entity.Property(e => e.IdExpediente).HasColumnName("id_expediente");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.Property(e => e.Ruta)
                    .IsUnicode(false)
                    .HasColumnName("ruta");

                entity.HasOne(d => d.IdExpedienteNavigation)
                    .WithMany(p => p.ArchivoXExternos)
                    .HasForeignKey(d => d.IdExpediente)
                    .HasConstraintName("FKDA21305584239BDA");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.ArchivoXExternos)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FKDA21305519B7956B");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("areas", "configuracion");

                entity.HasIndex(e => e.Abreviacion, "UQ_area_abreviacion_areas")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "UQ_area_codigo_areas")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "UQ_area_id_areas")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Abreviacion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("abreviacion");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdCentro).HasColumnName("id_centro");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");

                entity.Property(e => e.IdTipoArea).HasColumnName("id_tipo_area");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdTipoAreaNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.IdTipoArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("areas_fk");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.ToTable("cargos", "contratacion");

                entity.HasIndex(e => e.Id, "UQ_cargo_id")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "cargos_uq")
                    .IsUnique();

                entity.HasIndex(e => e.Codigo, "codigo");

                entity.HasIndex(e => new { e.IdPadre, e.IdNivelEscolaridad, e.IdGrupoEscala, e.IdCategoriaCargo, e.IdSolicitante }, "id_foraneo");

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

                entity.HasOne(d => d.IdCategoriaCargoNavigation)
                    .WithMany(p => p.CargoIdCategoriaCargoNavigations)
                    .HasForeignKey(d => d.IdCategoriaCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAE7C103793BB7C68");

                entity.HasOne(d => d.IdNivelEscolaridadNavigation)
                    .WithMany(p => p.CargoIdNivelEscolaridadNavigations)
                    .HasForeignKey(d => d.IdNivelEscolaridad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAE7C1037759105BC");

                entity.HasOne(d => d.IdTipoFuncionarioNavigation)
                    .WithMany(p => p.CargoIdTipoFuncionarioNavigations)
                    .HasForeignKey(d => d.IdTipoFuncionario)
                    .HasConstraintName("FKAE7C1037AD69E5D0");
            });

            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.ToTable("catalogos", "contratacion");

                entity.HasIndex(e => e.Id, "UQ_catalogos_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CatalogosDocumentosRequerido>(entity =>
            {
                entity.ToTable("catalogos_documentos_requeridos", "contratacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Prerequisito).HasColumnName("prerequisito");
            });

            modelBuilder.Entity<ElementosExterno>(entity =>
            {
                entity.ToTable("elementos_externos", "contratacion");

                entity.HasIndex(e => e.Identificacion, "codigo");

                entity.HasIndex(e => e.Identificacion, "elementos_externos_uq")
                    .IsUnique();

                entity.HasIndex(e => new { e.LicenciaConducir, e.Nacionalidad, e.Sexo, e.TipoSangre, e.EstadoCivil, e.CargoAspirado, e.IdRegionActual, e.IdRegionNatal, e.UnidadEstatura, e.UnidadPeso }, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.AspiracionSalarial).HasColumnName("aspiracion_salarial");

                entity.Property(e => e.CargoAspirado).HasColumnName("cargo_aspirado");

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

                entity.Property(e => e.LicenciaConducir).HasColumnName("licencia_conducir");

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

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono2");

                entity.Property(e => e.TipoSangre).HasColumnName("tipo_sangre");

                entity.Property(e => e.UnidadEstatura).HasColumnName("unidad_estatura");

                entity.Property(e => e.UnidadPeso).HasColumnName("unidad_peso");

                entity.HasOne(d => d.CargoAspiradoNavigation)
                    .WithMany(p => p.ElementosExternos)
                    .HasForeignKey(d => d.CargoAspirado)
                    .HasConstraintName("FKD082D503A56142C0");

                entity.HasOne(d => d.EstadoCivilNavigation)
                    .WithMany(p => p.ElementosExternoEstadoCivilNavigations)
                    .HasForeignKey(d => d.EstadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKD082D50318F887B6");

                entity.HasOne(d => d.IdRegionActualNavigation)
                    .WithMany(p => p.ElementosExternoIdRegionActualNavigations)
                    .HasForeignKey(d => d.IdRegionActual)
                    .HasConstraintName("FKD082D503889A34D8");

                entity.HasOne(d => d.IdRegionNatalNavigation)
                    .WithMany(p => p.ElementosExternoIdRegionNatalNavigations)
                    .HasForeignKey(d => d.IdRegionNatal)
                    .HasConstraintName("FKD082D503D1409068");

                entity.HasOne(d => d.LicenciaConducirNavigation)
                    .WithMany(p => p.ElementosExternoLicenciaConducirNavigations)
                    .HasForeignKey(d => d.LicenciaConducir)
                    .HasConstraintName("FKD082D5038599DE68");

                entity.HasOne(d => d.NacionalidadNavigation)
                    .WithMany(p => p.ElementosExternoNacionalidadNavigations)
                    .HasForeignKey(d => d.Nacionalidad)
                    .HasConstraintName("FKD082D5039514ADFD");

                entity.HasOne(d => d.SexoNavigation)
                    .WithMany(p => p.ElementosExternoSexoNavigations)
                    .HasForeignKey(d => d.Sexo)
                    .HasConstraintName("FKD082D503229C46A5");

                entity.HasOne(d => d.TipoSangreNavigation)
                    .WithMany(p => p.ElementosExternoTipoSangreNavigations)
                    .HasForeignKey(d => d.TipoSangre)
                    .HasConstraintName("FKD082D5031FF1A641");

                entity.HasOne(d => d.UnidadEstaturaNavigation)
                    .WithMany(p => p.ElementosExternoUnidadEstaturaNavigations)
                    .HasForeignKey(d => d.UnidadEstatura)
                    .HasConstraintName("FKD082D5037D9CEB0F");

                entity.HasOne(d => d.UnidadPesoNavigation)
                    .WithMany(p => p.ElementosExternoUnidadPesoNavigations)
                    .HasForeignKey(d => d.UnidadPeso)
                    .HasConstraintName("FKD082D50345D20F95");
            });

            modelBuilder.Entity<Especialidad>(entity =>
            {
                entity.ToTable("especialidad", "contratacion");

                entity.HasIndex(e => e.IdEstudio, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Especialidad1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("especialidad");

                entity.Property(e => e.IdEstudio).HasColumnName("id_estudio");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.Especialidads)
                    .HasForeignKey(d => d.IdEstudio)
                    .HasConstraintName("FKD51FB932757CE933");
            });

            modelBuilder.Entity<EspecialidadXEexterno>(entity =>
            {
                entity.ToTable("especialidad_x_eexterno", "contratacion");

                entity.HasIndex(e => new { e.IdEexterno, e.IdEspecialidad }, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

                entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.EspecialidadXEexternos)
                    .HasForeignKey(d => d.IdEexterno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("especialidad_x_eexterno_fk");

                entity.HasOne(d => d.IdEspecialidadNavigation)
                    .WithMany(p => p.EspecialidadXEexternos)
                    .HasForeignKey(d => d.IdEspecialidad)
                    .HasConstraintName("especialidad_x_eexterno_fk2");
            });

            modelBuilder.Entity<EstudiosXEexterno>(entity =>
            {
                entity.ToTable("estudios_x_eexterno", "contratacion");

                entity.HasIndex(e => new { e.IdEexterno, e.IdEstudio, e.Instituto }, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("comentario");

                entity.Property(e => e.Completado).HasColumnName("completado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaIncio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_incio");

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

                entity.Property(e => e.IdEstudio).HasColumnName("id_estudio");

                entity.Property(e => e.Instituto).HasColumnName("instituto");

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.EstudiosXEexternos)
                    .HasForeignKey(d => d.IdEexterno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2A62E9F87EA3FE11");

                entity.HasOne(d => d.IdEstudioNavigation)
                    .WithMany(p => p.EstudiosXEexternoIdEstudioNavigations)
                    .HasForeignKey(d => d.IdEstudio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2A62E9F8757CE933");

                entity.HasOne(d => d.InstitutoNavigation)
                    .WithMany(p => p.EstudiosXEexternoInstitutoNavigations)
                    .HasForeignKey(d => d.Instituto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK2A62E9F824962FFB");
            });

            modelBuilder.Entity<ExpedienteTmp>(entity =>
            {
                entity.ToTable("expediente_tmp", "contratacion");

                entity.HasIndex(e => e.IdEexterno, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

                entity.Property(e => e.Observaciones)
                    .HasColumnType("text")
                    .HasColumnName("observaciones");

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.ExpedienteTmps)
                    .HasForeignKey(d => d.IdEexterno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("expediente_tmp_fk");
            });

            modelBuilder.Entity<ExperienciaXEexterno>(entity =>
            {
                entity.ToTable("experiencia_x_eexterno", "contratacion");

                entity.HasIndex(e => new { e.IdEexterno, e.IdEmpresa }, "id_foraneo");

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

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

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

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.ExperienciaXEexternos)
                    .HasForeignKey(d => d.IdEexterno)
                    .HasConstraintName("FK3C79C3BD7EA3FE11");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.ExperienciaXEexternos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK3C79C3BD6B061F41");
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.ToTable("idioma", "configuracion");

                entity.HasIndex(e => e.Id, "UQ_idioma_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoIso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("codigo_iso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Seleccionado).HasColumnName("seleccionado");

                entity.Property(e => e.Traducido).HasColumnName("traducido");
            });

            modelBuilder.Entity<IdiomasXEexterno>(entity =>
            {
                entity.ToTable("idiomas_x_eexterno", "contratacion");

                entity.HasIndex(e => new { e.IdIdioma, e.IdEexterno }, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Escribir).HasColumnName("escribir");

                entity.Property(e => e.Escuchar).HasColumnName("escuchar");

                entity.Property(e => e.Hablar).HasColumnName("hablar");

                entity.Property(e => e.IdCalificativo).HasColumnName("id_calificativo");

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

                entity.Property(e => e.IdIdioma).HasColumnName("id_idioma");

                entity.Property(e => e.Leer).HasColumnName("leer");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("observaciones");

                entity.HasOne(d => d.EscribirNavigation)
                    .WithMany(p => p.IdiomasXEexternoEscribirNavigations)
                    .HasForeignKey(d => d.Escribir)
                    .HasConstraintName("FK13BD995291113CFB");

                entity.HasOne(d => d.EscucharNavigation)
                    .WithMany(p => p.IdiomasXEexternoEscucharNavigations)
                    .HasForeignKey(d => d.Escuchar)
                    .HasConstraintName("FK13BD99529138DED2");

                entity.HasOne(d => d.HablarNavigation)
                    .WithMany(p => p.IdiomasXEexternoHablarNavigations)
                    .HasForeignKey(d => d.Hablar)
                    .HasConstraintName("FK13BD9952D9638C50");

                entity.HasOne(d => d.IdCalificativoNavigation)
                    .WithMany(p => p.IdiomasXEexternoIdCalificativoNavigations)
                    .HasForeignKey(d => d.IdCalificativo)
                    .HasConstraintName("FK13BD9952C2B255AA");

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.IdiomasXEexternos)
                    .HasForeignKey(d => d.IdEexterno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK13BD99527EA3FE11");

                entity.HasOne(d => d.LeerNavigation)
                    .WithMany(p => p.IdiomasXEexternoLeerNavigations)
                    .HasForeignKey(d => d.Leer)
                    .HasConstraintName("FK13BD9952229915C2");
            });

            modelBuilder.Entity<LocalidadElementoExterno>(entity =>
            {
                entity.ToTable("localidad_elemento_externo", "contratacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstaActivo).HasColumnName("esta_activo");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.IdElementoExterno).HasColumnName("id_elemento_externo");

                entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");

                entity.Property(e => e.IdPais).HasColumnName("id_pais");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.LocalidadElementoExternoIdDepartamentoNavigations)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK846CAA996EA46284");

                entity.HasOne(d => d.IdElementoExternoNavigation)
                    .WithMany(p => p.LocalidadElementoExternos)
                    .HasForeignKey(d => d.IdElementoExterno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK846CAA992E182ACA");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.LocalidadElementoExternoIdMunicipioNavigations)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK846CAA9929A5AFA5");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.LocalidadElementoExternoIdPaisNavigations)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK846CAA9984E87D5B");
            });

            modelBuilder.Entity<MotivosDescarte>(entity =>
            {
                entity.ToTable("motivos_descarte", "seleccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EstadoMotivo).HasColumnName("estado_motivo");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion");

                entity.Property(e => e.IdUsuarioCreacion).HasColumnName("id_usuario_creacion");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("id_usuario_modificacion");

                entity.Property(e => e.NombreMotivo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre_motivo");

                entity.Property(e => e.TextoJustificativo).HasColumnName("texto_justificativo");
            });

            modelBuilder.Entity<ReferenciaParticularesEexterno>(entity =>
            {
                entity.ToTable("referencia_particulares_eexterno", "contratacion");

                entity.HasIndex(e => new { e.IdEexterno, e.IdRelacion }, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

                entity.Property(e => e.IdRelacion).HasColumnName("id_relacion");

                entity.Property(e => e.IdTipoReferencia).HasColumnName("id_tipo_referencia");

                entity.Property(e => e.NombreReferencia)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre_referencia");

                entity.Property(e => e.Ocupacion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ocupacion");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.ReferenciaParticularesEexternos)
                    .HasForeignKey(d => d.IdEexterno)
                    .HasConstraintName("FK365BF1B97EA3FE11");

                entity.HasOne(d => d.IdRelacionNavigation)
                    .WithMany(p => p.ReferenciaParticularesEexternoIdRelacionNavigations)
                    .HasForeignKey(d => d.IdRelacion)
                    .HasConstraintName("FK365BF1B98535682D");

                entity.HasOne(d => d.IdTipoReferenciaNavigation)
                    .WithMany(p => p.ReferenciaParticularesEexternoIdTipoReferenciaNavigations)
                    .HasForeignKey(d => d.IdTipoReferencia)
                    .HasConstraintName("FK365BF1B997E0A795");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("regiones", "configuracion");

                entity.HasIndex(e => e.Id, "UQ_regiones_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Seleccionado).HasColumnName("seleccionado");
            });

            modelBuilder.Entity<RequisicionPersonal>(entity =>
            {
                entity.ToTable("requisicion_personal", "seleccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Autorizado).HasColumnName("autorizado");

                entity.Property(e => e.Cerrada).HasColumnName("cerrada");

                entity.Property(e => e.DescripcionRequisicion).HasColumnName("descripcion_requisicion");

                entity.Property(e => e.DetalleJustificacion)
                    .HasMaxLength(100)
                    .HasColumnName("detalle_justificacion");

                entity.Property(e => e.EstadoRequisicion).HasColumnName("estado_requisicion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion");

                entity.Property(e => e.FechaRequisicion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_requisicion");

                entity.Property(e => e.FinMotivo)
                    .HasColumnType("datetime")
                    .HasColumnName("fin_motivo");

                entity.Property(e => e.IdAreaRequisicion).HasColumnName("id_area_requisicion");

                entity.Property(e => e.IdCargoColaboradorSolicita).HasColumnName("id_cargo_colaborador_solicita");

                entity.Property(e => e.IdCargoSolicitado).HasColumnName("id_cargo_solicitado");

                entity.Property(e => e.IdColaboradorSolicita).HasColumnName("id_colaborador_solicita");

                entity.Property(e => e.IdEstadoRequisicion).HasColumnName("id_estado_requisicion");

                entity.Property(e => e.IdJustificacionRequisicion).HasColumnName("id_justificacion_requisicion");

                entity.Property(e => e.IdMotivoRequisicion).HasColumnName("id_motivo_requisicion");

                entity.Property(e => e.IdPasoAutorizacion).HasColumnName("id_paso_autorizacion");

                entity.Property(e => e.IdSucursalRequisicion).HasColumnName("id_sucursal_requisicion");

                entity.Property(e => e.IdTipoContratacion).HasColumnName("id_tipo_contratacion");

                entity.Property(e => e.IdUsuarioCreacion).HasColumnName("id_usuario_creacion");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("id_usuario_modificacion");

                entity.Property(e => e.InicioMotivo)
                    .HasColumnType("datetime")
                    .HasColumnName("inicio_motivo");

                entity.Property(e => e.MotivoRechazo)
                    .HasMaxLength(300)
                    .HasColumnName("motivo_rechazo");

                entity.Property(e => e.ObservacionesRequisicion).HasColumnName("observaciones_requisicion");

                entity.Property(e => e.PeriodoEvaluacionMeses).HasColumnName("periodo_evaluacion_meses");

                entity.Property(e => e.RangoInicioSalarioConfirmado).HasColumnName("rango_inicio_salario_confirmado");

                entity.Property(e => e.Rechazado).HasColumnName("rechazado");

                entity.Property(e => e.SalarioMaximoCargo).HasColumnName("salario_maximo_cargo");
            });

            modelBuilder.Entity<TiposEmpleado>(entity =>
            {
                entity.ToTable("tipos_empleados", "contratacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<UsuariosXEexterno>(entity =>
            {
                entity.ToTable("usuarios_x_Eexterno", "contratacion");

                entity.HasIndex(e => new { e.IdUsuario, e.IdEexterno }, "id_foraneo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.IdEexterno).HasColumnName("id_eexterno");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdEexternoNavigation)
                    .WithMany(p => p.UsuariosXEexternos)
                    .HasForeignKey(d => d.IdEexterno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKA427C24B7EA3FE11");
            });

            modelBuilder.Entity<Vacante>(entity =>
            {
                entity.ToTable("vacantes", "seleccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DetallesVacante).HasColumnName("detalles_vacante");

                entity.Property(e => e.EsPublica).HasColumnName("es_publica");

                entity.Property(e => e.EstadoVacante).HasColumnName("estado_vacante");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaFinPublicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin_publicacion");

                entity.Property(e => e.FechaInicioPublicacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio_publicacion");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_modificacion");

                entity.Property(e => e.FechaRecepcionRequisicion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_recepcion_requisicion");

                entity.Property(e => e.IdColaboradorEncargado).HasColumnName("id_colaborador_encargado");

                entity.Property(e => e.IdColaboradorRecibe).HasColumnName("id_colaborador_recibe");

                entity.Property(e => e.IdRequisicion).HasColumnName("id_requisicion");

                entity.Property(e => e.IdUsuarioCreacion).HasColumnName("id_usuario_creacion");

                entity.Property(e => e.IdUsuarioModificacion).HasColumnName("id_usuario_modificacion");

                entity.Property(e => e.NivelRiesgoCargoActual).HasColumnName("nivel_riesgo_cargo_actual");

                entity.Property(e => e.NivelRiesgoCargoPrevio).HasColumnName("nivel_riesgo_cargo_previo");

                entity.Property(e => e.TipoSeleccion).HasColumnName("tipo_seleccion");

                entity.HasOne(d => d.IdRequisicionNavigation)
                    .WithMany(p => p.Vacantes)
                    .HasForeignKey(d => d.IdRequisicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__vacantes__id_req__710B0E66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
