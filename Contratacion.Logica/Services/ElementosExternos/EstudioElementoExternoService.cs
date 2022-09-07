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
    public class EstudioElementoExternoService : IEstudioElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public EstudioElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<EstudioElementoExternoVM> ListarEstudios(int idEexterno)
        {
            return _dbContext.EstudiosExternos
                             .Where(w => w.Activo == true && w.IdExterno == idEexterno)
                             .Select(s => new EstudioElementoExternoVM
                             {
                                 Id = s.Id,
                                 IdEexterno = s.IdExterno,
                                 IdEstudio = s.IdEstudio,
                                 FechaIncio = s.FechaIncio,
                                 FechaFin = s.FechaFin,
                                 NombreEstudio = s.Estudio.Nombre,
                                 NombreInstituto = s.Instituto,
                                 Comentario = s.Comentario,
                                 Completado = s.Completado
                             }).ToList();
        }

        public GeneralResponse GuardarEstudio(EstudioElementoExternoVM request)
        {
            try
            {
                var entidad = _mapper.Map<EstudiosExterno>(request);

                _dbContext.EstudiosExternos.Add(entidad);
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

        public GeneralResponse ActualizarEstudio(EstudioElementoExternoVM request)
        {
            try
            {
                var entidad = _dbContext.EstudiosExternos.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(EstudioElementoExternoVM), typeof(EstudiosExterno));
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

        public GeneralResponse EliminarEstudio(int id)
        {
            try
            {
                var entidad = _dbContext.EstudiosExternos.Find(id);
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
    }
}
