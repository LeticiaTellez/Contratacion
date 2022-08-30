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
    public class EspecialidadElementoExternoService : IEspecialidadElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public EspecialidadElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<EspecialidadElementoExternoVM> ListarEspecialidades(int idEexterno)
        {
            return _dbContext.EspecialidadExternos
                             .Where(w => w.Activo == true && w.IdExterno == idEexterno)
                             .Select(s => new EspecialidadElementoExternoVM
                             {
                                 Id = s.Id,
                                 IdEexterno = s.IdExterno,
                                 IdEspecialidad = s.IdEspecialidad,
                                 NombreEspecialidad = s.Especialidad.Nombre,
                                 Comentario = s.Comentario
                             }).ToList();
        }

        public GeneralResponse GuardarEspecialidad(EspecialidadElementoExternoVM request)
        {
            try
            {
                var entidad = _mapper.Map<EspecialidadExterno>(request);

                _dbContext.EspecialidadExternos.Add(entidad);
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

        public GeneralResponse ActualizarEspecialidad(EspecialidadElementoExternoVM request)
        {
            try
            {
                var entidad = _dbContext.EspecialidadExternos.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(EspecialidadElementoExternoVM), typeof(EspecialidadExterno));
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

        public GeneralResponse EliminarEspecialidad(int id)
        {
            try
            {
                var entidad = _dbContext.EspecialidadExternos.Find(id);
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
