using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class BranchOfficesService : IBranchOfficesService
    {
        private readonly APINegociosDbContext _db;

        public BranchOfficesService(APINegociosDbContext dbContext)
        {
            _db = dbContext;
        }

        public bool IsCread(BranchOffices creadBranchs)
        {
            try
            {
                creadBranchs.IsCreadAt = DateTime.Now;
                creadBranchs.IsCreadBy = true;
                creadBranchs.IsStatud = true;

                _db.Add(creadBranchs);
                return IsSaveAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public bool IsDeleted(BranchOffices branchs)
        {
            try
            {
                var _getDeleted = _db.Set<BranchOffices>().Find(branchs.BranchId);
                if (_getDeleted != null)
                {
                    _getDeleted.IsDeletedBy = true;
                    _getDeleted.IsStatud = false;
                    _getDeleted.IsDeletedAt = DateTime.Now;
                    _db.SaveChanges();

                }

                //_db.Set<BranchOffices>().Remove(branchs);
                //if (branchs == null)
                //    throw new ArgumentNullException("Error! No se ingreso el ID");

                return IsSaveAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public bool IsExisteByBranchOfficesCode(string code)
        {
            try
            {
                bool existeBranch = _db.Set<BranchOffices>().Any(e => e.BranchOfficesCode.ToLower().Trim() == code.ToLower().Trim());
                return existeBranch;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public bool IsExisteByBranchOfficesId(int branchId)
        {
            try
            {
                return _db.Set<BranchOffices>().Any(e => e.BranchId == branchId);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public bool IsExisteByBranchOfficesName(string name)
        {
            try
            {
                bool existeBranchName = _db.Set<BranchOffices>().Any(e => e.BranchOfficesName.ToLower().Trim() == name.ToLower().Trim());
                return existeBranchName;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public bool IsSaveAll()
        {
            try
            {
                return _db.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public bool IsUpdated(BranchOffices updatedBranchs)
        {
            try
            {
                //_db.Update(updatedBranchs);

                var _updatedBranchOffice = GetByBranchOfficeId(updatedBranchs.BranchId) ?? throw new ArgumentNullException("Error! El Id ingresado no esta registrado a ninguna Sucursal");

                _updatedBranchOffice.BranchId = updatedBranchs.BranchId;
                _updatedBranchOffice.BranchOfficesName = updatedBranchs.BranchOfficesName;
                _updatedBranchOffice.Direccion = updatedBranchs.Direccion;
                _updatedBranchOffice.BranchOfficesCode = updatedBranchs.BranchOfficesCode;
                _updatedBranchOffice.Direccion = _updatedBranchOffice.Direccion;
                _updatedBranchOffice.Contacts = updatedBranchs.Contacts;
                _updatedBranchOffice.Referencia = updatedBranchs.Referencia;
                _updatedBranchOffice.WebSite = updatedBranchs.WebSite;
                _updatedBranchOffice.FacebookAccount = updatedBranchs.FacebookAccount;
                _updatedBranchOffice.InstagramAccount = updatedBranchs.InstagramAccount;
                _updatedBranchOffice.WhatsAppNumber = updatedBranchs.WhatsAppNumber;
                _updatedBranchOffice.PhoneNumber = updatedBranchs.PhoneNumber;
                _updatedBranchOffice.OtherNumber = updatedBranchs.OtherNumber;
                _updatedBranchOffice.Latitud = updatedBranchs.Latitud;
                _updatedBranchOffice.Longitud = updatedBranchs.Longitud;
                _updatedBranchOffice.IsStatud = updatedBranchs.IsStatud;
                updatedBranchs.IsUpdatedAt = DateTime.Now;
                updatedBranchs.IsUpdatedBy = true;
                updatedBranchs.IsDeletedAt = null;
                updatedBranchs.IsDeletedBy = false;

                _db.Entry(_updatedBranchOffice).State = EntityState.Modified;
                return IsSaveAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public ICollection<BranchOffices> GetBranchOffices()
        {
            try
            {
                return _db.Set<BranchOffices>().OrderBy(e => e.BranchOfficesName)
                                                     .AsNoTracking()
                                                     .ToList();

            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public ICollection<BranchOffices> GetByBranchOfficeCode(string code)
        {
            try
            {
                IQueryable<BranchOffices> query = _db.Set<BranchOffices>();
                if (!string.IsNullOrEmpty(code))
                    query = query.Where(e => e.BranchOfficesCode.Contains(code) || e.BranchOfficesCode.Contains(code));


                return query.AsNoTracking()
                            .ToList();


                //_db.Set<BranchOffices>().FirstOrDefault(e => e.BranchOfficesCode == code);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public BranchOffices GetByBranchOfficeId(int Id)
        {
            try
            {
                return _db.Set<BranchOffices>().FirstOrDefault(e => e.BranchId == Id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public ICollection<BranchOffices> GetBranchOfficeByName(string name)
        {
            try
            {
                IQueryable<BranchOffices> query = _db.Set<BranchOffices>();

                if (!string.IsNullOrEmpty(name))
                    query = query.Where(e => e.BranchOfficesName.Contains(name) || e.Description.Contains(name));

                return query.AsNoTracking()
                             .ToList();


                //_db.Set<BranchOffices>().FirstOrDefault(e => e.BranchOfficesName.ToLower().Trim() == name.ToLower().Trim());
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public ICollection<BranchOffices> GetByBranchOfficeIsDeleted(/*string branchDeleted*/)
        {
            try
            {
                return _db.Set<BranchOffices>()
                     .Where(e => !e.IsDeletedBy)
                     .OrderBy(e => e.BranchId)
                     .ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible recuperar los registro eliminado, por favor validar que el registro fue eliminado", ex);
            }
        }
    }
}
