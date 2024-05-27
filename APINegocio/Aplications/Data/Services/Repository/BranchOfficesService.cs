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
                _db.Set<BranchOffices>().Remove(branchs);
                if (branchs == null)
                    throw new ArgumentNullException("Error! No se ingreso el ID");

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
                _db.Update(updatedBranchs);
                return IsSaveAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }

        public ICollection<BranchOffices> List()
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

        public ICollection<BranchOffices> ListByCode(string code)
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

        public BranchOffices ListById(int Id)
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

        public ICollection<BranchOffices> ListByName(string name)
        {
            try
            {
                IQueryable<BranchOffices> query = _db.Set<BranchOffices>();

                if (!string.IsNullOrEmpty(name))
                    query = query.Where(e => e.BranchOfficesName.Contains(name) || e.Description.Contains(name));

                return  query.AsNoTracking()
                             .ToList();
                    
                    
                    //_db.Set<BranchOffices>().FirstOrDefault(e => e.BranchOfficesName.ToLower().Trim() == name.ToLower().Trim());
            }
            catch (Exception ex)
            {

                throw new Exception("Error!", ex);
            }
        }
    }
}
