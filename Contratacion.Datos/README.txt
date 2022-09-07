El SeguridadDBContext ha sido generado con Code First, es decir que para hacer un cambio en cualquier tabla del esquema de seguridad
se haría primero en las entidades (clases) del proyecto y después se ejecutaría la migración con el comando Add-Migration y Update-Database 
para que se apliquen a la base de datos.

En el caso de ContratacionDBContext se usó Reverse Engineering, esto permite generar entidades (clases) de tablas creadas previamente en la 
base de datos (DatabaseFirst) para ello se usa el comando: Scaffold-DbContext connectionString Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models 
-Tables contratacion.elementos_externos, 
contratacion.experiencia_x_eexterno, contratacion.estudios_x_eexterno, contratacion.especialidad_x_eexterno, contratacion.archivo_x_externo, 
contratacion.referencia_particulares_eexterno, contratacion.localidad_elemento_externo, contratacion.idiomas_x_eexterno, contratacion.catalogos, 
configuracion.regiones, contratacion.cargos, contratacion.catalogos_documentos_requeridos, contratacion.expediente_tmp, contratacion.especialidad 
-Context "ContratacionDbContext" -Force especificando las tablas que se importarán al proyecto.
-Force es para reescribir las clases que ya existen. (si se le cambia el nombre a alguna clase esta no se reemplaza, solo se deja de utilizar y el 
Scaffold crea otra con el nombre original). Más documentación sobre esto en: https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=vs

TABLAS INCLUIDAS HASTA AHORA:
Scaffold-DbContext "Server=192.168.20.62\SQL2014;Database=b2g_rrhh_triton_migracion;User Id=USR_H2C; Password=uSx!a2u_e@" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables contratacion.elementos_externos, contratacion.experiencia_x_eexterno, contratacion.estudios_x_eexterno, contratacion.especialidad_x_eexterno, contratacion.archivo_x_externo, contratacion.referencia_particulares_eexterno, contratacion.localidad_elemento_externo, contratacion.idiomas_x_eexterno, contratacion.catalogos, configuracion.regiones, contratacion.cargos, contratacion.catalogos_documentos_requeridos, contratacion.expediente_tmp, contratacion.especialidad, seleccion.aplicantes_vacante, seleccion.vacantes, configuracion.idioma, seleccion.requisicion_personal, seleccion.motivos_descarte, contratacion.usuarios_x_Eexterno, contratacion.tipos_empleados, configuracion.areas -Context "ContratacionDbContext" -Force