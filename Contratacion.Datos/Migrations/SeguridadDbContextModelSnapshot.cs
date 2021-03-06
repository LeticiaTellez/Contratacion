// <auto-generated />
using System;
using Contratacion.Datos.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contratacion.Datos.Migrations
{
    [DbContext(typeof(SeguridadDbContext))]
    partial class SeguridadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contratacion.Datos.Seguridad.InicioSesionUsuario", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("InicioSesionProvedor");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ClaveProveedor");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombreProveedor");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdUsuario");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("InicioSesionUsuarios", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.ParametrosConfiguracion", b =>
                {
                    b.Property<int>("IdParametro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreParametro")
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("ValorFecha")
                        .HasColumnType("datetime");

                    b.Property<double?>("ValorNumerico")
                        .HasColumnType("float");

                    b.Property<string>("ValorTexto")
                        .HasColumnType("nvarchar(800)");

                    b.HasKey("IdParametro");

                    b.ToTable("ParametrosConfiguracion", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.ReclamacionRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoReclamacion");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValorReclamacion");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdRol");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ReclamacionRoles", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.ReclamacionUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoReclamacion");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ValorReclamacion");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdUsuario");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ReclamacionesUsuario", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.Rol", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IdRol")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MomentoConcurrencia");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NombreRol");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NombreRolNormalizado");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NombreRolNormalizado] IS NOT NULL");

                    b.ToTable("Roles", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.RolUsuarios", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdUsuario");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdRol");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolesUsuarios", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.TokenUsuario", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("InicioSesionProveedor");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Valor");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("TokenUsuario", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IdUsuario")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("CantidadErroresAcceso");

                    b.Property<string>("CodigoConfirmacionCorreo")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Correo");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("CorreoConfirmado");

                    b.Property<DateTime?>("FechaEnvioCodigo")
                        .HasColumnType("datetime");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("HabilitarBloquedo");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("BloquearHasta");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("CorreoNormalizado");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("UsuarioNormalizado");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ClaveHash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefono");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("TelefonoConfirmado");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelloSeguridad");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("DosFactores");

                    b.Property<DateTime>("UltimaActualizacionClave")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[UsuarioNormalizado] IS NOT NULL");

                    b.ToTable("Usuarios", "seguridad");
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.InicioSesionUsuario", b =>
                {
                    b.HasOne("Contratacion.Datos.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.ReclamacionRoles", b =>
                {
                    b.HasOne("Contratacion.Datos.Seguridad.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.ReclamacionUsuario", b =>
                {
                    b.HasOne("Contratacion.Datos.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.RolUsuarios", b =>
                {
                    b.HasOne("Contratacion.Datos.Seguridad.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contratacion.Datos.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contratacion.Datos.Seguridad.TokenUsuario", b =>
                {
                    b.HasOne("Contratacion.Datos.Seguridad.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
