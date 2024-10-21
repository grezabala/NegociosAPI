using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Services.Interfaz.IContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class OperacionesService : IOperacionesService
    {
        public readonly APINegociosDbContext _db;
        public readonly IMapper _mapper;

        public OperacionesService(APINegociosDbContext aPINegocioDbContext, IMapper mapper)
        {
            _db = aPINegocioDbContext;
            _mapper = mapper;
        }

        public ICollection<Operaciones> GetOperacionesByTipo(string tipo)
        {
            try
            {
                IQueryable<Operaciones> query = _db.Set<Operaciones>();
                query = query.Where(x => x.Tipo.Contains(tipo.ToLower().Trim()) || x.Tipo.Contains(tipo.ToLower().Trim()));

                return query.OrderBy(x => x.Tipo).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Operaciones GetOperacionesDtoById(int Id)
        {
            try
            {
                return _db.Set<Operaciones>().OrderBy(e => e.Tipo).FirstOrDefault(e => e.OperacionId == Id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }

        public ICollection<Operaciones> GetOperacionesDtos()
        {
            try
            {
                return _db.Set<Operaciones>().OrderBy(e => e.OperacionId).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }

        public Operaciones IsCread(Operaciones cread)
        {
            try
            {
                if (cread != null)
                {
                    cread.IsUpdatedAt = null;
                    cread.IsDeletedAt = null;
                    cread.IsDeletedBy = false;
                    cread.IsUpdatedBy = false;
                    cread.IsStatu = true;
                    cread.Fecha = DateTime.Now;

                    _db.Set<Operaciones>().Add(cread);
                    _db.SaveChanges();
                }
                throw new ArgumentNullException("El formulario se envio vacio.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }

        public bool IsDeleted(Operaciones operaciones)
        {
            try
            {
                var _deleted = GetOperacionesDtoById(operaciones.OperacionId);
                if (operaciones != null)
                {
                    _deleted.IsDeletedBy = true;
                    _deleted.IsDeletedAt = DateTime.Now;
                    _deleted.IsStatu = false;

                    _db.SaveChanges();

                }

                return _db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }

        public Operaciones IsUpdated(Operaciones updated)
        {
            try
            {
                var _getUpdated = GetOperacionesDtoById(updated.OperacionId) ?? throw new ArgumentNullException("Error...! No se encontro el ID.");

                _getUpdated.Tipo = updated.Tipo;
                _getUpdated.Producto = updated.Producto;
                _getUpdated.Stock = updated.Stock;
                _getUpdated.Cantidad = updated.Cantidad;
                _getUpdated.Fecha = updated.Fecha;

                updated.IsStatu = true;
                updated.IsDeletedAt = null;
                updated.IsUpdatedAt = DateTime.Now;
                updated.IsUpdatedBy = true;
                updated.IsDeletedBy = false;

                _db.Entry(_getUpdated).State = EntityState.Modified;
                _db.SaveChanges();
                return _getUpdated;

            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }
    }
}
