using Contratacion.Datos.Models;
using Contratacion.Logica.Interfaces;
using Contratacion.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Contratacion.Logica.Services
{
    public class DropDownService : IDropDownService
    {
        private readonly ContratacionDbContext _dbContext;

        public DropDownService(ContratacionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DropDownResponse> cmbObtenerCatalogos(int idPadre)
        {
            return _dbContext.Catalogos
                .Where(w => w.Estado == true && w.IdPadre == idPadre)
                .Select(s => new DropDownResponse
                { Id = s.Id, Text = s.Nombre }).ToList();
        }

        public List<DropDownResponse> cmbObtenerRegiones()
        {
            return _dbContext.Regiones
                .Where(w => w.Estado == true && w.IdPadre == 0)
                .Select(s => new DropDownResponse
                {  Id = s.Id, Text = s.Nombre }).ToList();
        }

        public List<DropDownResponse> cmbObtenerCargos()
        {
            return _dbContext.Cargos
                .Where(w => w.Activo == true)
                .Select(s => new DropDownResponse
                { Id = s.Id, Text = s.Nombre }).ToList();
        }

        public List<DropDownResponse> cmbObtenerEspecialidades()
        {
            return _dbContext.Especialidads
                .Where(w => w.Activo == true)
                .Select(s => new DropDownResponse
                { Id = s.Id, Text = s.Descripcion }).ToList();
        }

        public List<DropDownResponse> cmbObtenerIdiomas()
        {
            return _dbContext.Idiomas
                .Where(w => w.Estado == true)
                .Select(s => new DropDownResponse
                { Id = s.Id, Text = s.Nombre }).ToList();
        }

        public List<DropDownResponse> cmbObtenerTiposDocumento()
        {
            return _dbContext.CatalogosDocumentosRequeridos
                .Where(w => w.Estado == true)
                .Select(s => new DropDownResponse
                { Id = s.Id, Text = s.Nombre }).ToList();
        }
    }
}
