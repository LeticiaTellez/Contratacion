using System;
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
                    || w.Telefono1 == request.Telefono1
                    || w.CorreoElectronico == request.CorreoElectronico
                    || (!string.IsNullOrWhiteSpace(request.NoSeguroSocial) && w.NoSeguroSocial == request.NoSeguroSocial));
        }

        private void GuardarExpediente(int idElemento, string codigo) 
        {
            ExpedienteTmp entidad = new ExpedienteTmp
            {
                IdEexterno = idElemento,
                Codigo = codigo,
                Observaciones = "Ingreso Elemento Externo",
                Activo = true
            };

            _dbContext.ExpedienteTmps.Add(entidad);
            _dbContext.SaveChanges();
        }

        private void GuardarUsuarioElemento(int idElemento, int idUsuario)
        {
            UsuariosXEexterno entidad = new UsuariosXEexterno
            {
                IdUsuario = idUsuario,
                IdEexterno = idElemento,
                Activo = true
            };

            _dbContext.UsuariosXEexternos.Add(entidad);
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

            response.NombreCargoAspirado = entidad.CargoAspiradoNavigation?.Nombre;
            response.NombreEstadoCivil = entidad.EstadoCivilNavigation?.Nombre;
            response.NombreLicenciaConducir = entidad.LicenciaConducirNavigation?.Nombre;
            response.NombreNacionalidad = entidad.NacionalidadNavigation?.Nombre;
            response.NombreRegionActual = entidad.IdRegionActualNavigation?.Nombre;
            response.NombreRegionNatal = entidad.IdRegionNatalNavigation?.Nombre;
            response.NombreSexo = entidad.SexoNavigation?.Nombre;
            response.NombreTipoSangre = entidad.TipoSangreNavigation?.Nombre;
            response.NombreUnidadEstatura = entidad.UnidadEstaturaNavigation?.Nombre;
            response.NombreUnidadPeso = entidad.UnidadPesoNavigation?.Nombre;

            return response;
        }

        public int FindEExternoUsuario(int idUsuario) 
        {
            return _dbContext.UsuariosXEexternos
                .Where(w => w.IdUsuario == idUsuario)
                .FirstOrDefault()?.IdEexterno ?? 0;
        }
    }
}
