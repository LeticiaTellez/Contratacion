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
    public class ExperienciaElementoExternoService : IExperienciaElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExperienciaElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ExperienciaElementoExternoVM> ListarExperiencias(int idEexterno)
        {
            return _dbContext.ExperienciaExternos
                             .Where(w => w.Activo == true && w.IdExterno == idEexterno)
                             .Select(s => new ExperienciaElementoExternoVM
                             {
                                 Id = s.Id,
                                 IdEexterno = s.IdExterno,
                                 CargoDesempenado = s.CargoDesempenado,
                                 IdEmpresa = s.IdEmpresa,
                                 SueldoMensual = s.SueldoMensual,
                                 NombreEmpresa = s.Empresa.Nombre,
                                 FechaInicio = s.FechaInicio,
                                 FechaFin = s.FechaFin,
                                 FichaLaboral = s.FichaLaboral,
                                 MotivoRetiro = s.MotivoRetiro,
                                 NombreJefe = s.NombreJefe,
                                 CagoJefe = s.CagoJefe
                             }).ToList();
        }

        public GeneralResponse GuardarExperiencia(ExperienciaElementoExternoVM request)
        {
            try
            {
                var entidad = _mapper.Map<ExperienciaExterno>(request);

                _dbContext.ExperienciaExternos.Add(entidad);
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

        public GeneralResponse ActualizarExperiencia(ExperienciaElementoExternoVM request)
        {
            try
            {
                var entidad = _dbContext.ExperienciaExternos.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(ExperienciaElementoExternoVM), typeof(ExperienciaExterno));
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

        public GeneralResponse EliminarExperiencia(int id)
        {
            try
            {
                var entidad = _dbContext.ExperienciaExternos.Find(id);
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
