using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contratacion.Datos.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "seleccion");

            migrationBuilder.EnsureSchema(
                name: "contratacion");

            migrationBuilder.EnsureSchema(
                name: "configuracion");

            migrationBuilder.EnsureSchema(
                name: "seguridad");

            migrationBuilder.CreateTable(
                name: "Catalogos",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPadre = table.Column<int>(type: "int", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentosRequerido",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prerequisito = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentosRequerido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                schema: "configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Traducido = table.Column<bool>(type: "bit", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    Seleccionado = table.Column<bool>(type: "bit", nullable: true),
                    CodigoIso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivosDescarte",
                schema: "seleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_motivo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    texto_justificativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_usuario_creacion = table.Column<int>(type: "int", nullable: false),
                    id_usuario_modificacion = table.Column<int>(type: "int", nullable: true),
                    estado_motivo = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosDescarte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosConfiguracion",
                schema: "seguridad",
                columns: table => new
                {
                    IdParametro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreParametro = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    ValorNumerico = table.Column<double>(type: "float", nullable: true),
                    ValorFecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    ValorTexto = table.Column<string>(type: "nvarchar(800)", nullable: true),
                    NombreCategoria = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosConfiguracion", x => x.IdParametro);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                schema: "configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPadre = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    Seleccionado = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequisicionPersonal",
                schema: "seleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha_requisicion = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_justificacion_requisicion = table.Column<int>(type: "int", nullable: false),
                    detalle_justificacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_motivo_requisicion = table.Column<int>(type: "int", nullable: false),
                    inicio_motivo = table.Column<DateTime>(type: "datetime", nullable: true),
                    fin_motivo = table.Column<DateTime>(type: "datetime", nullable: true),
                    id_tipo_contratacion = table.Column<int>(type: "int", nullable: false),
                    id_area_requisicion = table.Column<int>(type: "int", nullable: false),
                    id_sucursal_requisicion = table.Column<int>(type: "int", nullable: false),
                    id_colaborador_solicita = table.Column<int>(type: "int", nullable: false),
                    id_cargo_colaborador_solicita = table.Column<int>(type: "int", nullable: false),
                    id_cargo_solicitado = table.Column<int>(type: "int", nullable: false),
                    salario_maximo_cargo = table.Column<double>(type: "float", nullable: true),
                    rango_inicio_salario_confirmado = table.Column<double>(type: "float", nullable: false),
                    periodo_evaluacion_meses = table.Column<double>(type: "float", nullable: true),
                    descripcion_requisicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    observaciones_requisicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    autorizado = table.Column<bool>(type: "bit", nullable: true),
                    rechazado = table.Column<bool>(type: "bit", nullable: true),
                    motivo_rechazo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    id_estado_requisicion = table.Column<int>(type: "int", nullable: false),
                    id_paso_autorizacion = table.Column<int>(type: "int", nullable: false),
                    cerrada = table.Column<bool>(type: "bit", nullable: true),
                    id_usuario_creacion = table.Column<int>(type: "int", nullable: false),
                    id_usuario_modificacion = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisicionPersonal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "seguridad",
                columns: table => new
                {
                    IdRol = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NombreRolNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MomentoConcurrencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "TiposEmpleados",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEmpleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "seguridad",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    CodigoConfirmacionCorreo = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    FechaEnvioCodigo = table.Column<DateTime>(type: "datetime", nullable: true),
                    UltimaActualizacionClave = table.Column<DateTime>(type: "datetime", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UsuarioNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CorreoNormalizado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CorreoConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    ClaveHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelloSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoConfirmado = table.Column<bool>(type: "bit", nullable: false),
                    DosFactores = table.Column<bool>(type: "bit", nullable: false),
                    BloquearHasta = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    HabilitarBloquedo = table.Column<bool>(type: "bit", nullable: false),
                    CantidadErroresAcceso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "configuracion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_padre = table.Column<int>(type: "int", nullable: true),
                    id_tipo_area = table.Column<int>(type: "int", nullable: false),
                    codigo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    abreviacion = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: true),
                    descripcion = table.Column<string>(type: "varchar(350)", unicode: false, maxLength: 350, nullable: true),
                    id_empresa = table.Column<int>(type: "int", nullable: true),
                    id_centro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                    table.ForeignKey(
                        name: "areas_fk",
                        column: x => x.id_tipo_area,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                schema: "contratacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_padre = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    id_nivel_escolaridad = table.Column<int>(type: "int", nullable: false),
                    id_grupo_escala = table.Column<int>(type: "int", nullable: false),
                    id_categoria_cargo = table.Column<int>(type: "int", nullable: false),
                    fecha_elaboracion = table.Column<DateTime>(type: "datetime", nullable: false),
                    descripcion_generica = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    observaciones = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    salario_base = table.Column<double>(type: "float", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: true),
                    Id_solicitante = table.Column<int>(type: "int", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true),
                    codigo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    salario_hasta = table.Column<double>(type: "float", nullable: true),
                    id_tipo_funcionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.id);
                    table.ForeignKey(
                        name: "FKAE7C1037759105BC",
                        column: x => x.id_nivel_escolaridad,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKAE7C103793BB7C68",
                        column: x => x.id_categoria_cargo,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKAE7C1037AD69E5D0",
                        column: x => x.id_tipo_funcionario,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstudio = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    EstudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidades_Catalogos_EstudioId",
                        column: x => x.EstudioId,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacantes",
                schema: "seleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_requisicion = table.Column<int>(type: "int", nullable: false),
                    fecha_recepcion_requisicion = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_colaborador_recibe = table.Column<int>(type: "int", nullable: false),
                    nivel_riesgo_cargo_previo = table.Column<double>(type: "float", nullable: true),
                    nivel_riesgo_cargo_actual = table.Column<double>(type: "float", nullable: false),
                    id_colaborador_encargado = table.Column<int>(type: "int", nullable: false),
                    fecha_inicio_publicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_fin_publicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    es_publica = table.Column<bool>(type: "bit", nullable: true),
                    tipo_seleccion = table.Column<int>(type: "int", nullable: false),
                    detalles_vacante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_usuario_creacion = table.Column<int>(type: "int", nullable: false),
                    id_usuario_modificacion = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK__vacantes__id_req__710B0E66",
                        column: x => x.id_requisicion,
                        principalSchema: "seleccion",
                        principalTable: "RequisicionPersonal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReclamacionRoles",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    TipoReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacionRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclamacionRoles_Roles_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "seguridad",
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InicioSesionUsuarios",
                schema: "seguridad",
                columns: table => new
                {
                    InicioSesionProvedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaveProveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InicioSesionUsuarios", x => new { x.InicioSesionProvedor, x.ClaveProveedor });
                    table.ForeignKey(
                        name: "FK_InicioSesionUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReclamacionesUsuario",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    TipoReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorReclamacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamacionesUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReclamacionesUsuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolesUsuarios",
                schema: "seguridad",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdRol = table.Column<long>(type: "bigint", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUsuarios", x => new { x.IdUsuario, x.IdRol });
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "seguridad",
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUsuarios_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TokenUsuario",
                schema: "seguridad",
                columns: table => new
                {
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    InicioSesionProveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenUsuario", x => new { x.IdUsuario, x.InicioSesionProveedor, x.Nombre });
                    table.ForeignKey(
                        name: "FK_TokenUsuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "seguridad",
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementosExternos",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AspiracionSalarial = table.Column<double>(type: "float", nullable: true),
                    Contratado = table.Column<int>(type: "int", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoSeguroSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstadoCivil = table.Column<int>(type: "int", nullable: true),
                    IdCargoAspirado = table.Column<int>(type: "int", nullable: true),
                    NumLicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    IdRegionActual = table.Column<int>(type: "int", nullable: true),
                    CargoAspiradoId = table.Column<int>(type: "int", nullable: true),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: true),
                    RegionActualId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementosExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementosExternos_Cargos_CargoAspiradoId",
                        column: x => x.CargoAspiradoId,
                        principalSchema: "contratacion",
                        principalTable: "Cargos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementosExternos_Catalogos_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementosExternos_Regiones_RegionActualId",
                        column: x => x.RegionActualId,
                        principalSchema: "configuracion",
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AplicantesVacante",
                schema: "seleccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_vacante = table.Column<int>(type: "int", nullable: false),
                    id_candidato = table.Column<int>(type: "int", nullable: false),
                    aceptacion_terminos = table.Column<bool>(type: "bit", nullable: true),
                    aspiracion_salarial = table.Column<double>(type: "float", nullable: true),
                    es_descartado = table.Column<bool>(type: "bit", nullable: true),
                    es_prechequeado = table.Column<bool>(type: "bit", nullable: true),
                    fecha_prechequeo = table.Column<DateTime>(type: "datetime", nullable: true),
                    califica_entrevista = table.Column<bool>(type: "bit", nullable: true),
                    comentarios_prechequeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    formato_prechequeo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_motivo_descarte = table.Column<int>(type: "int", nullable: true),
                    fecha_descarte = table.Column<DateTime>(type: "datetime", nullable: true),
                    comentarios_aplicante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_modificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicantesVacante", x => x.Id);
                    table.ForeignKey(
                        name: "FK__aplicante__id_mo__74DB9F4A",
                        column: x => x.id_motivo_descarte,
                        principalSchema: "seleccion",
                        principalTable: "MotivosDescarte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__aplicante__id_va__73E77B11",
                        column: x => x.id_vacante,
                        principalSchema: "seleccion",
                        principalTable: "Vacantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadExternos",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdExterno = table.Column<int>(type: "int", nullable: true),
                    IdEspecialidad = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    ExternoId = table.Column<int>(type: "int", nullable: true),
                    EspecialidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecialidadExternos_ElementosExternos_ExternoId",
                        column: x => x.ExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EspecialidadExternos_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalSchema: "contratacion",
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudiosExternos",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdExterno = table.Column<int>(type: "int", nullable: false),
                    IdEstudio = table.Column<int>(type: "int", nullable: false),
                    Instituto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completado = table.Column<bool>(type: "bit", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaIncio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    ExternoId = table.Column<int>(type: "int", nullable: true),
                    EstudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiosExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudiosExternos_Catalogos_EstudioId",
                        column: x => x.EstudioId,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudiosExternos_ElementosExternos_ExternoId",
                        column: x => x.ExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expedientes",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdExterno = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    ExternoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expedientes_ElementosExternos_ExternoId",
                        column: x => x.ExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienciaExternos",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FichaLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoRetiro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreJefe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SueldoMensual = table.Column<double>(type: "float", nullable: true),
                    IdExterno = table.Column<int>(type: "int", nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    CagoJefe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoDesempenado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternoId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienciaExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienciaExternos_Catalogos_EmpresaId",
                        column: x => x.EmpresaId,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExperienciaExternos_ElementosExternos_ExternoId",
                        column: x => x.ExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdiomasExternos",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdIdioma = table.Column<int>(type: "int", nullable: false),
                    IdExterno = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Escribir = table.Column<int>(type: "int", nullable: true),
                    Escuchar = table.Column<int>(type: "int", nullable: true),
                    Hablar = table.Column<int>(type: "int", nullable: true),
                    Leer = table.Column<int>(type: "int", nullable: true),
                    IdCalificativo = table.Column<int>(type: "int", nullable: true),
                    CalificativoId = table.Column<int>(type: "int", nullable: true),
                    ElementoExternoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdiomasExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdiomasExternos_Catalogos_CalificativoId",
                        column: x => x.CalificativoId,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdiomasExternos_ElementosExternos_ElementoExternoId",
                        column: x => x.ElementoExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReferenciasExterno",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreReferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTipoReferencia = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    IdExterno = table.Column<int>(type: "int", nullable: true),
                    ElementoExternoId = table.Column<int>(type: "int", nullable: true),
                    TipoReferenciaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenciasExterno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenciasExterno_Catalogos_TipoReferenciaId",
                        column: x => x.TipoReferenciaId,
                        principalSchema: "contratacion",
                        principalTable: "Catalogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReferenciasExterno_ElementosExternos_ElementoExternoId",
                        column: x => x.ElementoExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosExterno",
                schema: "contratacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdExterno = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    ElementoExternoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosExterno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosExterno_ElementosExternos_ElementoExternoId",
                        column: x => x.ElementoExternoId,
                        principalSchema: "contratacion",
                        principalTable: "ElementosExternos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchivoExterno",
                schema: "contratacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    observaciones = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    id_tipo_documento = table.Column<int>(type: "int", nullable: true),
                    id_expediente = table.Column<int>(type: "int", nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: true),
                    ruta = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fecha_recepcion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoExterno", x => x.id);
                    table.ForeignKey(
                        name: "FKDA21305519B7956B",
                        column: x => x.id_tipo_documento,
                        principalSchema: "contratacion",
                        principalTable: "DocumentosRequerido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKDA21305584239BDA",
                        column: x => x.id_expediente,
                        principalSchema: "contratacion",
                        principalTable: "Expedientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicantesVacante_id_motivo_descarte",
                schema: "seleccion",
                table: "AplicantesVacante",
                column: "id_motivo_descarte");

            migrationBuilder.CreateIndex(
                name: "IX_AplicantesVacante_id_vacante",
                schema: "seleccion",
                table: "AplicantesVacante",
                column: "id_vacante");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoExterno_id_expediente",
                schema: "contratacion",
                table: "ArchivoExterno",
                column: "id_expediente");

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoExterno_id_tipo_documento",
                schema: "contratacion",
                table: "ArchivoExterno",
                column: "id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_id_tipo_area",
                schema: "configuracion",
                table: "Areas",
                column: "id_tipo_area");

            migrationBuilder.CreateIndex(
                name: "UQ_area_abreviacion_areas",
                schema: "configuracion",
                table: "Areas",
                column: "abreviacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_area_codigo_areas",
                schema: "configuracion",
                table: "Areas",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_area_id_areas",
                schema: "configuracion",
                table: "Areas",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "cargos_uq",
                schema: "contratacion",
                table: "Cargos",
                column: "codigo",
                unique: true,
                filter: "[codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "codigo",
                schema: "contratacion",
                table: "Cargos",
                column: "codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_id_categoria_cargo",
                schema: "contratacion",
                table: "Cargos",
                column: "id_categoria_cargo");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_id_nivel_escolaridad",
                schema: "contratacion",
                table: "Cargos",
                column: "id_nivel_escolaridad");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_id_tipo_funcionario",
                schema: "contratacion",
                table: "Cargos",
                column: "id_tipo_funcionario");

            migrationBuilder.CreateIndex(
                name: "UQ_cargo_id",
                schema: "contratacion",
                table: "Cargos",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElementosExternos_CargoAspiradoId",
                schema: "contratacion",
                table: "ElementosExternos",
                column: "CargoAspiradoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosExternos_EstadoCivilId",
                schema: "contratacion",
                table: "ElementosExternos",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosExternos_RegionActualId",
                schema: "contratacion",
                table: "ElementosExternos",
                column: "RegionActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_EstudioId",
                schema: "contratacion",
                table: "Especialidades",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadExternos_EspecialidadId",
                schema: "contratacion",
                table: "EspecialidadExternos",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadExternos_ExternoId",
                schema: "contratacion",
                table: "EspecialidadExternos",
                column: "ExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosExternos_EstudioId",
                schema: "contratacion",
                table: "EstudiosExternos",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosExternos_ExternoId",
                schema: "contratacion",
                table: "EstudiosExternos",
                column: "ExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedientes_ExternoId",
                schema: "contratacion",
                table: "Expedientes",
                column: "ExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaExternos_EmpresaId",
                schema: "contratacion",
                table: "ExperienciaExternos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienciaExternos_ExternoId",
                schema: "contratacion",
                table: "ExperienciaExternos",
                column: "ExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_IdiomasExternos_CalificativoId",
                schema: "contratacion",
                table: "IdiomasExternos",
                column: "CalificativoId");

            migrationBuilder.CreateIndex(
                name: "IX_IdiomasExternos_ElementoExternoId",
                schema: "contratacion",
                table: "IdiomasExternos",
                column: "ElementoExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_InicioSesionUsuarios_IdUsuario",
                schema: "seguridad",
                table: "InicioSesionUsuarios",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacionesUsuario_IdUsuario",
                schema: "seguridad",
                table: "ReclamacionesUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ReclamacionRoles_IdRol",
                schema: "seguridad",
                table: "ReclamacionRoles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciasExterno_ElementoExternoId",
                schema: "contratacion",
                table: "ReferenciasExterno",
                column: "ElementoExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenciasExterno_TipoReferenciaId",
                schema: "contratacion",
                table: "ReferenciasExterno",
                column: "TipoReferenciaId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "seguridad",
                table: "Roles",
                column: "NombreRolNormalizado",
                unique: true,
                filter: "[NombreRolNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUsuarios_IdRol",
                schema: "seguridad",
                table: "RolesUsuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "seguridad",
                table: "Usuarios",
                column: "CorreoNormalizado");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "seguridad",
                table: "Usuarios",
                column: "UsuarioNormalizado",
                unique: true,
                filter: "[UsuarioNormalizado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosExterno_ElementoExternoId",
                schema: "contratacion",
                table: "UsuariosExterno",
                column: "ElementoExternoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacantes_id_requisicion",
                schema: "seleccion",
                table: "Vacantes",
                column: "id_requisicion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicantesVacante",
                schema: "seleccion");

            migrationBuilder.DropTable(
                name: "ArchivoExterno",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "configuracion");

            migrationBuilder.DropTable(
                name: "EspecialidadExternos",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "EstudiosExternos", 
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "ExperienciaExternos",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Idiomas",
                schema: "configuracion");

            migrationBuilder.DropTable(
                name: "IdiomasExternos",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "InicioSesionUsuarios",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ParametrosConfiguracion",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ReclamacionesUsuario",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ReclamacionRoles",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ReferenciasExterno", 
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "RolesUsuarios",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "TiposEmpleados", 
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "TokenUsuario",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "UsuariosExterno",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "MotivosDescarte",
                schema: "seleccion");

            migrationBuilder.DropTable(
                name: "Vacantes",
                schema: "seleccion");

            migrationBuilder.DropTable(
                name: "DocumentosRequerido",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Expedientes",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Especialidades",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "RequisicionPersonal",
                schema: "seleccion");

            migrationBuilder.DropTable(
                name: "ElementosExternos",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Cargos",
                schema: "contratacion");

            migrationBuilder.DropTable(
                name: "Regiones", 
                schema: "configuracion");

            migrationBuilder.DropTable(
                name: "Catalogos", 
                schema: "contratacion");
        }
    }
}
