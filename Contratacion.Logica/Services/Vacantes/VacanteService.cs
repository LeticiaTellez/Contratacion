using Contratacion.Datos.Models;
using Contratacion.Logica.Interfaces.Vacantes;
using Contratacion.Modelos;
using Contratacion.Modelos.Vacantes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contratacion.Logica.Services.Vacantes
{
    public class VacanteService : IVacanteService
    {
        private readonly ContratacionDbContext _dbContext;

        public VacanteService(ContratacionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<VacanteVM> ListarVacantes()
        {
            return (from vac in _dbContext.Vacantes
                    join rp in _dbContext.RequisicionPersonals on vac.IdRequisicion equals rp.Id
                    join car in _dbContext.Cargos on rp.IdCargoSolicitado equals car.Id
                    join cat in _dbContext.Catalogos on rp.IdSucursalRequisicion equals cat.Id
                    join te in _dbContext.TiposEmpleados on rp.IdTipoContratacion equals te.Id
                    where vac.EstadoVacante == true && vac.EsPublica == true && rp.Cerrada == false
                    && rp.Autorizado == true && vac.FechaFinPublicacion >= DateTime.Now
                    select new VacanteVM
                    {
                        Id = vac.Id,
                        NombreCargo = car.Nombre,
                        DescripcionCargo = rp.DescripcionRequisicion,
                        DetallesVacante = vac.DetallesVacante,
                        FechaInicioPublicacion = vac.FechaInicioPublicacion,
                        FechaFinPublicacion = vac.FechaFinPublicacion,
                        SalarioMaximo = rp.SalarioMaximoCargo ?? 0,
                        NombreSucursal = cat.Nombre,
                        NombreTipoContrato = te.Descripcion,
                        IdArea = rp.IdAreaRequisicion
                    }).OrderByDescending(o => o.FechaInicioPublicacion).ToList();
        }

        public List<AreaResponse> ListarAreas()
        {
            var areas = (from vac in _dbContext.Vacantes
                    join rp in _dbContext.RequisicionPersonals on vac.IdRequisicion equals rp.Id
                    join area in _dbContext.Areas on rp.IdAreaRequisicion equals area.Id 
                    where vac.EstadoVacante == true && vac.EsPublica == true
                    && rp.Autorizado == true && vac.FechaFinPublicacion >= DateTime.Now
                    select new AreaResponse
                    {
                        Id = area.Id,
                        Nombre = area.Nombre,
                        CantidadVacantes = vac.Id
                    }).ToList();

            return areas.GroupBy(g => g.Id)
                .Select(s => new AreaResponse 
                {
                    Id = s.Key,
                    Nombre = s.FirstOrDefault().Nombre,
                    CantidadVacantes = s.Count()
                }).ToList();
        }
    }
}
