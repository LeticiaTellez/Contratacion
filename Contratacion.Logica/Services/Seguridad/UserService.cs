using Contratacion.Datos;
using Contratacion.Datos.Models;
using Contratacion.Logica.Interfaces.Seguridad;
using Contratacion.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Contratacion.Logica.Services.Seguridad
{
    public class UserService : IUserService
    {
        private readonly ContratacionDbContext _dbContext;
        private readonly ContratacionDbContext _dbContContext;

        public UserService(Datos.ContratacionDbContext dbContext, ContratacionDbContext dbContContext)
        {
            _dbContext = dbContext;
            _dbContContext = dbContContext;
        }

        public long GetIdUser(string userName)
        {
            string normalizedUserName = userName.ToUpper();
            return _dbContext.Usuarios
                             .Where(w => w.NormalizedUserName == normalizedUserName)
                             .FirstOrDefault().Id;
        }

        public GeneralResponse SetCodeEmail(Usuario user, string code)
        {
            try
            {
                user.CodigoConfirmacionCorreo = code;
                user.FechaEnvioCodigo = DateTime.Now;

                _dbContext.Entry(user).State = EntityState.Modified;
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

        public GeneralResponse UpdateEmailConfirmed(Usuario user, string code)
        {
            try
            {
                var expirationHours = 24;
                var hoursDiff = (DateTime.Now - user.FechaEnvioCodigo.Value).TotalHours;

                if (!(user.CodigoConfirmacionCorreo == code && hoursDiff < expirationHours))
                {
                    return new GeneralResponse
                    {
                        Status = false,
                        Errors = new List<string> { $"El código {code} no coincide o ha expirado" }
                    };
                }

                user.EmailConfirmed = true;
                _dbContext.Entry(user).State = EntityState.Modified;
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

        public GeneralResponse UpdateEmailUnconfirmed(Usuario user)
        {
            try
            {
                user.EmailConfirmed = false;
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();

                UpdateEmailElementoExterno(user.Id, user.Email);
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

        public void UpdateEmailElementoExterno(long idUsuario, string correo) 
        {
            int idElemento = _dbContContext.UsuariosExterno
                .Where(w => w.IdUsuario == idUsuario)
                .FirstOrDefault().IdExterno;

            var elemento = _dbContContext.ElementosExternos.Find(idElemento);
            elemento.CorreoElectronico = correo;

            _dbContContext.Entry(elemento).State = EntityState.Modified;
            _dbContContext.SaveChanges();
        }
    }
}
