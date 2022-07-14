using AutoMapper;
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
    public class LocalidadElementoExternoService : ILocalidadElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public LocalidadElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<LocalidadElementoExternoVM> ListarLocalidades(int idEexterno)
        {
            return _dbContext.LocalidadElementoExternos
                             .Where(w => w.EstaActivo == 1 && w.IdElementoExterno == idEexterno)
                             .Select(s => new LocalidadElementoExternoVM
                             {
                                 Id = s.Id,
                                 IdPais = s.IdPais,
                                 IdDepartamento = s.IdDepartamento,
                                 IdMunicipio = s.IdMunicipio,
                                 NombrePais = s.IdPaisNavigation.Nombre,
                                 NombreDepartamento = s.IdDepartamentoNavigation.Nombre,
                                 NombreMunicipio = s.IdMunicipioNavigation.Nombre
                             }).ToList();
        }

        public GeneralResponse GuardarLocalidad(LocalidadElementoExternoVM request)
        {
            try
            {
                var entidad = _mapper.Map<LocalidadElementoExterno>(request);

                _dbContext.LocalidadElementoExternos.Add(entidad);
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

        public GeneralResponse ActualizarLocalidad(LocalidadElementoExternoVM request)
        {
            try
            {
                var entidad = _dbContext.LocalidadElementoExternos.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(LocalidadElementoExternoVM), typeof(LocalidadElementoExterno));
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

        public GeneralResponse EliminarLocalidad(int id)
        {
            try
            {
                var entidad = _dbContext.LocalidadElementoExternos.Find(id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {id} no encontrado" }
                    };
                }

                entidad.EstaActivo = 0;
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
