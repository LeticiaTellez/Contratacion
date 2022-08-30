using AutoMapper;
using Contratacion.Datos;
using Contratacion.Datos.Models;
using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos;
using Contratacion.Modelos.ElementosExternos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contratacion.Logica.Services.ElementosExternos
{
    public class ArchivoElementoExternoService : IArchivoElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArchivoElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ArchivoElementoExternoVM> ListarArchivos(int idEexterno)
        {
            return _dbContext.ArchivosExterno
                             .Where(w => w.Activo == true && w.Expediente.IdExterno == idEexterno)
                             .Select(s => new ArchivoElementoExternoVM
                             {
                                 Id = s.Id,
                                 IdExpediente = s.IdExpediente,
                                 IdTipoDocumento = s.IdTipoDocumento,
                                 NombreTipoDocumento = s.DocumentosRequerido.Nombre,
                                 FechaRecepcion = s.FechaRecepcion,
                                 Observaciones = s.Observaciones,
                                 Ruta = s.Ruta
                             }).ToList();
        }

        public GeneralResponse GuardarArchivo(ArchivoElementoExternoVM request)
        {
            try
            {
                request.IdExpediente = ObtenerIdExpediente(request.IdEexterno);
                request.FechaRecepcion = DateTime.Now;

                var entidad = _mapper.Map<ArchivoExterno>(request);

                _dbContext.ArchivosExterno.Add(entidad);
                _dbContext.SaveChanges();

                return new GeneralResponse { Status = true };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        public GeneralResponse EliminarArchivo(int id)
        {
            try
            {
                var entidad = _dbContext.ArchivosExterno.Find(id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {id} no encontrado" }
                    };
                }

                entidad.Activo = false;
                _dbContext.Entry(entidad).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return new GeneralResponse { Status = true };
            }
            catch (Exception ex)
            {
                return new GeneralResponse
                {
                    Status = false,
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        int ObtenerIdExpediente(int idEexterno) 
        {
            return _dbContext.Expedientes
                .Where(w => w.IdExterno == idEexterno && w.Activo == true)
                .FirstOrDefault().Id;
        }
    }
}
