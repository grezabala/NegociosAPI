using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class InventoryService : IInventoryService
    {
        private readonly APINegociosDbContext _db;
        public InventoryService(APINegociosDbContext aPINegociosDbContext)
        {
            _db = aPINegociosDbContext;
        }

        #region INVENTORY METHOD
        public async Task<ICollection<Inventory>> GetInventoryAsync()
        {
            try
            {

                // return await _db.Set<Inventory>().OrderBy(e => e.InventoryId).AsNoTracking().ToListAsync();

                if (_db == null)
                    throw new ArgumentNullException("Error! _APINegociosDb es null");

                if (_db.Inventory == null)
                    throw new ArgumentNullException("Error! Invetory esta llegando null");

                var getInventory = await (from inv in _db.Inventory
                                          select inv)
                                    .OrderBy(e => e.InventoryName)
                                    .ToListAsync();

                var datos = getInventory;

                return getInventory;
            }
            catch (WebException ex)
            {

                throw ex.InnerException;
            }

        }

        public async Task<Inventory> GetByInventoryId(int Id)
        {
            try
            {

                return await _db.Set<Inventory>().OrderBy(e => e.InventoryId == Id)
                    .FirstOrDefaultAsync(e => e.InventoryId == Id);

                //var getById = _db?.Inventory != null ?
                //    (from getInventory in _db.Inventory select getInventory)
                //    .OrderBy(e => e.InventoryId)
                //    .ToListAsync() : null;

                //return getById;

                //var getById = (from getId in _APINegociosDb?.Inventory != n
                //               where getId.InventoryId == Id
                //               select getId).ToListAsync();

                //return await getById;
            }
            catch (WebException ex)
            {

                throw ex.InnerException;
            }

        }

        public async Task<ICollection<Inventory>> GetByCodeInventory(string code)
        {
            try
            {

                if (code != null)
                {
                    return await _db.Set<Inventory>()
                          .Where(e => e.CodigoInventory == code)
                          .OrderBy(e => e.CodigoInventory)
                          .ToListAsync();

                }
                throw new InvalidOperationException("Error....! No sé fue posible mostrar el Inventario, no indico ningún código." +
                    " Por favor  del inventario que desea consultar");

                //Esta consulta genera un error
                //var getCode = _db.Inventory.Where(c => c.CodigoInventory.Any(char.IsLetterOrDigit) &&
                //c.CodigoInventory.Contains(code))
                //    .OrderBy(e => e.CodigoInventory)
                //    .ToListAsync();

                ////ERROR NO MUESTRA LA DATA

                //return await getCode;
            }
            catch (WebException ex)
            {

                throw ex.GetBaseException();
            }

        }

        public async Task<ICollection<Inventory>> GetByInventoryName(string name)
        {
            try
            {


                if (name != null)
                {
                    return await _db.Set<Inventory>()
                        .Where(e => e.InventoryName == name)
                        .OrderBy(e => e.InventoryId)
                        .ToListAsync();

                }
                throw new InvalidOperationException("Error....! No sé fue posible mostrar el Inventario, no indico ningún nombre." +
                    " Por favor indicar el nombre del inventario que desea consultar.");

                //var getByName = _db.Set<Inventory>().Where(e => e.InventoryName.Any(char.IsLetterOrDigit)
                //&& e.InventoryName.Contains(name))
                //    .OrderBy(e => e.InventoryName)
                //    .AsNoTracking()
                //    .ToListAsync();

                //return await getByName;

                ////var getByName = (from getName in _APINegociosDb.Inventory
                ////                 where getName.InventoryName == name
                ////                 select getName).ToListAsync();

                ////return await getByName;
            }
            catch (WebException ex)
            {

                throw ex.GetBaseException();
            }
        }
        public async Task<Inventory> GetByInventoriesNumber(int number)
        {
            try
            {
                //return await _db.Set<Inventory>().OrderBy(e => e.NumberInventory == number).FirstOrDefaultAsync(e => e.NumberInventory == number);

                if (number > 0)
                {
                    var getByNumber = await _db.Set<Inventory>().FirstOrDefaultAsync(e => e.NumberInventory == number);
                    return getByNumber;
                }

                return new Inventory();

                ////Esta consulta genera un error
                //var getNumber = (from num in _db.Inventory
                //                 where num.NumberInventory == number
                //                 select num)
                //                 .AsNoTracking()
                //                 .OrderBy(e => e.NumberInventory)
                //                 .ToListAsync();

                //return await getNumber;
            }
            catch (WebException ex)
            {

                throw ex.InnerException;
            }

        }

        public bool IsCread(Inventory cread)
        {
            try
            {
                if (cread != null)
                {

                    cread.IsDateCread = DateTime.Now;
                    cread.IsDeleted = false;
                    cread.IsDeletedAt = null;
                    cread.IsUpdated = false;
                    cread.IsUpdatedAt = null;
                    cread.IsShipped = true;
                    cread.IsStatus = true;
                    cread.StoresStorId = cread.StorId;

                    _db.Add(cread);
                    return IsSaveAll();
                }

                throw new InvalidOperationException("Error! El registro llego vacio, por favor completar el formulario.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salió mal al agregar el nuevo inventario.", ex);
            }
        }

        public async Task<bool> IsUpdated(Inventory updated)
        {
            try
            {
                var _updatedInventario = await GetByInventoryId(updated.InventoryId) ??
                    throw new ArgumentNullException("Error! El ID ingresado no esta relacionado con ningún Inventario. Por favor validar si el ID esta correcto.");

                _updatedInventario.InventoryId = updated.InventoryId;
                _updatedInventario.InventoryName = updated.InventoryName;
                _updatedInventario.DescrictionInventory = updated.DescrictionInventory;
                _updatedInventario.ReferenceInventory = updated.ReferenceInventory;
                _updatedInventario.NumberInventory = updated.NumberInventory;
                _updatedInventario.CodigoInventory = updated.CodigoInventory;
                _updatedInventario.DateCread = null;
                _updatedInventario.StorId = updated.StorId;
                _updatedInventario.ShoppingId = updated.ShoppingId;
                _updatedInventario.ProductoId = updated.ProductoId;
                _updatedInventario.ProductoId = updated.ProductoId;
                _updatedInventario.IsDateCread = null;
                _updatedInventario.IsShipped = true;      
                _updatedInventario.IsUpdated = true;
                _updatedInventario.IsUpdatedAt = DateTime.Now;
                _updatedInventario.IsStatus = true;
                _updatedInventario.StoresStorId = _updatedInventario.StorId;
                updated.IsDeleted = false;
                updated.IsDeletedAt = null;

                _db.Entry(_updatedInventario).State = EntityState.Modified;
                return IsSaveAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible modificar el registro.", ex);
            }
        }

        public async Task<bool> IsDeleted(Inventory deleted)
        {
            try
            {
                var _getIsDeleted = await _db.Set<Inventory>().FindAsync(deleted.InventoryId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;
                    _getIsDeleted.IsShipped = false;
                    _getIsDeleted.IsStatus = false;

                    await _db.SaveChangesAsync();

                }

                return IsSaveAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExisteGetInventarioByNumber(int number)
        {
            try
            {
                return _db.Set<Inventory>().Any(e => e.NumberInventory == number);
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible validar la existencia del Inventario, por favor verificar si el número es el correcto.", ex);
            }
        }

        public bool IsExisteGetInventarioByCode(string code)
        {
            try
            {
                bool existe = _db.Set<Inventory>().Any(e => e.CodigoInventory.ToLower().Trim() == code.ToLower().Trim());
                return existe;
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible validar la existencia del Inventario, por favor verificar si el código es el correcto.", ex);
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

                throw new Exception("Error! No fue posible registrar el nuevo inventarios.", ex);
            }
        }

        #endregion
    }
}
