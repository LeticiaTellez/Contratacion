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
    public class IdiomaElementoExternoService : IIdiomaElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public IdiomaElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<IdiomaElementoExternoVM> ListarIdiomas(int idEexterno)
        {
            return (from iee in _dbContext.IdiomasExternos
                    join idio in _dbContext.Idiomas on iee.IdIdioma equals idio.Id
                    where iee.Activo == true && idio.Estado == true && iee.IdExterno == idEexterno
                    select new IdiomaElementoExternoVM
                    {
                        Id = iee.Id,
                        IdCalificativo = iee.IdCalificativo,
                        IdIdioma = iee.IdIdioma,
                        Escribir = iee.Escribir,
                        Escuchar = iee.Escuchar,
                        Leer = iee.Leer,
                        Hablar = iee.Hablar,
                        NombreIdioma = idio.Nombre,
                        NombreCalificativo = iee.Calificativo.Nombre,
                        Observaciones = iee.Observaciones
                    }).ToList();
        }

        public GeneralResponse GuardarIdioma(IdiomaElementoExternoVM request)
        {
            try
            {
                var entidad = _mapper.Map<IdiomasExterno>(request);

                _dbContext.IdiomasExternos.Add(entidad);
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

        public GeneralResponse ActualizarIdioma(IdiomaElementoExternoVM request)
        {
            try
            {
                var entidad = _dbContext.IdiomasExternos.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(IdiomaElementoExternoVM), typeof(IdiomasExterno));
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

        public GeneralResponse EliminarIdioma(int id)
        {
            try
            {
                var entidad = _dbContext.IdiomasExternos.Find(id);
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
