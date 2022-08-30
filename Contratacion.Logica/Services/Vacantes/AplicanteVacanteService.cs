using AutoMapper;
using Contratacion.Datos;
using Contratacion.Datos.Models;
using Contratacion.Logica.Interfaces.Vacantes;
using Contratacion.Modelos;
using Contratacion.Modelos.Vacantes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contratacion.Logica.Services.Vacantes
{
    public class AplicanteVacanteService : IAplicanteVacanteService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly IMapper _mapper;

        public AplicanteVacanteService(ContratacionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GeneralResponse GuardarAplicacion(AplicanteVacanteVM request)
        {
            try
            {
                if (ExisteAplicacion(request.IdCandidato, request.IdVacante))
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { "Ya has aplicado a esta vacante" }
                    };
                }

                var entidad = _mapper.Map<AplicantesVacante>(request);
                entidad.AceptacionTerminos = true;
                entidad.FechaCreacion = DateTime.Now;

                _dbContext.AplicantesVacante.Add(entidad);
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

        private bool ExisteAplicacion(int idCandidato, int idVacante) 
        {
            return _dbContext.AplicantesVacante.Any(w => w.Estado == true
                        && w.IdCandidato == idCandidato && w.IdVacante == idVacante);
        }
    }
}
