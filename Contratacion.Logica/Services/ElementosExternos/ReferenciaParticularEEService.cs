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
    public class ReferenciaParticularEEService : IReferenciaParticularEEService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReferenciaParticularEEService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ReferenciaParticularEEVM> ListarRerenciasParticulares(int idEexterno)
        {
            return _dbContext.ReferenciasExterno
                             .Where(w => w.Activo == true && w.IdExterno == idEexterno)
                             .Select(s => new ReferenciaParticularEEVM
                             {
                                 Id = s.Id,
                                 IdEexterno = s.IdExterno,
                                 IdRelacion = s.IdRelacion,
                                 IdTipoReferencia = s.IdTipoReferencia,
                                 NombreReferencia = s.NombreReferencia,
                                 NombreTipoReferencia = s.TipoReferencia.Nombre,
                                 NombreRelacion = s.Relacion.Nombre,
                                 Direccion = s.Direccion,
                                 Ocupacion = s.Ocupacion,
                                 Telefono = s.Telefono
                             }).ToList();
        }

        public GeneralResponse GuardarReferenciaParticular(ReferenciaParticularEEVM request)
        {
            try
            {
                var entidad = _mapper.Map<ReferenciasExterno>(request);

                _dbContext.ReferenciasExterno.Add(entidad);
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

        public GeneralResponse ActualizarReferenciaParticular(ReferenciaParticularEEVM request)
        {
            try
            {
                var entidad = _dbContext.ReferenciasExterno.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(ReferenciaParticularEEVM), typeof(ReferenciasExterno));
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

        public GeneralResponse EliminarReferenciaParticular(int id)
        {
            try
            {
                var entidad = _dbContext.ReferenciasExterno.Find(id);
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
