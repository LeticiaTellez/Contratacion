using System;
using Contratacion.Datos;
using Contratacion.Datos.Models;
using Contratacion.Modelos;
using Contratacion.Logica.Interfaces.ElementosExternos;
using Contratacion.Modelos.ElementosExternos;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Contratacion.Logica.Services.ElementosExternos
{
    public class ElementoExternoService : IElementoExternoService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public ElementoExternoService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GeneralResponse GuardarElementoExterno(ElementoExternoRequest request)
        {
            try
            {
                if (ExisteElementoExterno(request)) 
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { "Esta identificación ya ha sido registrada." }
                    };
                }

                var entidad = _mapper.Map<ElementosExterno>(request);

                _dbContext.ElementosExternos.Add(entidad);
                _dbContext.SaveChanges();

                GuardarExpediente(entidad.Id, request.Identificacion);
                GuardarUsuarioElemento(entidad.Id, request.IdUsuario);

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

        private bool ExisteElementoExterno(ElementoExternoRequest request)
        {
            var lista = _dbContext.ElementosExternos.ToList();
            lista = (request.Id > 0) ? lista.Where(w => w.Id != request.Id).ToList() : lista;

            return lista.Any(w => w.Identificacion.Replace("-","") == request.Identificacion.Replace("-", "")
                    || w.Telefono == request.Telefono
                    || w.CorreoElectronico == request.CorreoElectronico
                    || (!string.IsNullOrWhiteSpace(request.NoSeguroSocial) && w.NoSeguroSocial == request.NoSeguroSocial));
        }

        private void GuardarExpediente(int idElemento, string codigo) 
        {
            Expediente entidad = new Expediente
            {
                IdExterno = idElemento,
                Codigo = codigo,
                Observaciones = "Ingreso Elemento Externo",
                Activo = true
            };

            _dbContext.Expedientes.Add(entidad);
            _dbContext.SaveChanges();
        }

        private void GuardarUsuarioElemento(int idElemento, int idUsuario)
        {
            UsuariosExterno entidad = new UsuariosExterno
            {
                IdUsuario = idUsuario,
                IdExterno = idElemento,
                Activo = true
            };

            _dbContext.UsuariosExterno.Add(entidad);
            _dbContext.SaveChanges();
        }

        public GeneralResponse ActualizarElementoExterno(ElementoExternoRequest request)
        {
            try
            {
                var entidad = _dbContext.ElementosExternos.Find(request.Id);
                if (entidad == null)
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"Registro {request.Id} no encontrado" }
                    };
                }
                
                if (ExisteElementoExterno(request))
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { "Este código ya ha sido registrado" }
                    };
                }

                _mapper.Map(request, entidad, typeof(ElementoExternoRequest), typeof(ElementosExterno));
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

        public ElementoExternoResponse DetallarElementoExterno(int id)
        {
            var entidad = _dbContext.ElementosExternos.Find(id);
            if (entidad == null) return new ElementoExternoResponse();

            var response = _mapper.Map<ElementoExternoResponse>(entidad);

            response.NombreCargoAspirado = entidad.CargoAspirado?.Nombre;
            response.NombreEstadoCivil = entidad.EstadoCivil?.Nombre;
            response.NombreNacionalidad = entidad.Nacionalidad;
            response.NombreRegionActual = entidad.RegionActual?.Nombre;
            response.NombreSexo = entidad.Sexo;

            return response;
        }

        public int FindEExternoUsuario(int idUsuario) 
        {
            return _dbContext.UsuariosExterno
                .Where(w => w.IdUsuario == idUsuario)
                .FirstOrDefault()?.IdExterno ?? 0;
        }
    }
}
