using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class ShoppingService : IShoppingService
    {
        private readonly APINegociosDbContext _db;
        public ShoppingService(APINegociosDbContext aPINegociosDbContext)
        {
            _db = aPINegociosDbContext;
        }

        #region SHOPPING METHOD
        public async Task<ICollection<Shopping>> GetShoppings()
        {
            try
            {
                var getShopping = await _db.Set<Shopping>()
                    .OrderBy(e => e.ShoppingName)
                    .AsNoTracking()
                    .ToListAsync();


                return getShopping;
            }
            catch (Exception ex)
            {

                throw new Exception("Error! Al mostrar todos las compras", ex);
            }

        }

        public async Task<Shopping> GetShoppingByIdAsync(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    return await _db.Shoppings.FirstOrDefaultAsync(x => x.ShoppingId == Id);

                }
                throw new InvalidOperationException("Error...! Algo salió mal al mostrar su compra.");

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontro ninguna compra relacionada a ese ID, por favor verificar que el ID sea el correcto.", ex);
            }

        }

        public async Task<ICollection<Shopping>> GetShoppingByNameAsync(string names)
        {
            try
            {

                IQueryable<Shopping> query = _db.Set<Shopping>();
                if (!string.IsNullOrEmpty(names))
                    query = query.Where(e => e.ShoppingName.Contains(names) || e.ShoppingName.Contains(names));

                return await query.AsNoTracking().ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontro ninguna compra relacionada con el nombre suministrado, por favor verificar que el nombre esta correcto.", ex);
            }

        }

        public async Task<Shopping> GetShoppingByNumberShopping(int number)
        {
            try
            {
                return await _db.Shoppings.OrderBy(e => e.NumberShopping).FirstOrDefaultAsync(x => x.NumberShopping == number);

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontro ninguna compra relacionada al número suministrado, por favor verificar que el número esta correcto.", ex);
            }

        }

        public async Task<Shopping> GetShoppingByCodeAsync(string code)
        {
            try
            {
                return await _db.Shoppings.OrderBy(e => e.ShoppingCode).FirstOrDefaultAsync(x => x.ShoppingCode == code);

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontro ninguna compra relacionada al código suministrado, por favor verificar que código esta correcto.", ex);
            }

        }

        public bool GetShoppingByIsDeleted(Shopping shopping)
        {
            try
            {
                var _getIsDeleted = _db.Shoppings.Find(shopping.ShoppingId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsAsset = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;

                    _db.SaveChanges();
                }

                return IsSave();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro.", ex);
            }
        }

        public bool IsCread(Shopping cread)
        {
            try
            {
                if (cread != null)
                {
                    cread.ShoppingStatus = 1;
                    cread.IsDeleted = false;
                    cread.IsDeletedAt = null;
                    cread.IsAsset = true;
                    cread.IsShoppingDate = DateTime.Now;
                    cread.IsModifedShopping = null;
                    cread.IsModified = false;
                    cread.IsDeletedAt = null;

                    _db.Add(cread);
                    return IsSave();
                }
                throw new InvalidOperationException("El formulario esta vacio.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al registrar su compra.", ex);
            }
        }

        public bool IsExisteShoppingByName(string name)
        {
            try
            {
                bool existeName = _db.Set<Shopping>().Any(e => e.ShoppingName.ToLower().Trim() == name.ToLower().Trim());
                return existeName;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al validar si la compra existe compra.", ex);
            }
        }

        public bool IsExisteShoppingByCode(string code)
        {
            try
            {
                bool _existeCode = _db.Set<Shopping>().Any(e => e.ShoppingCode.ToLower().Trim() == code.ToLower().Trim());
                return _existeCode;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al validar si la compra existe compra.", ex);
            }
        }

        public bool IsSave()
        {
            try
            {
                return _db.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió al guardar su compra.", ex);
            }
        }

        public bool IsUpdated(Shopping shopping)
        {
            try
            {
                var _getShopping = GetShoppingByIdAsync(shopping.ShoppingId).Result ?? throw new ArgumentNullException("Error! El Id ingresado no esta registrado a ninguna Sucursal");

                _getShopping.OrderId = shopping.OrderId;
                _getShopping.ShoppingId = shopping.ShoppingId;
                _getShopping.ShoppingName = shopping.ShoppingName;
                _getShopping.ShoppingDescription = shopping.ShoppingDescription;
                _getShopping.ShoppingStatus = shopping.ShoppingStatus;
                _getShopping.ShoppingCount = shopping.ShoppingCount;
                _getShopping.ShoppingTitle = shopping.ShoppingTitle;
                _getShopping.ShoppingCode = shopping.ShoppingCode;
                _getShopping.NumberShopping = shopping.NumberShopping;
                shopping.IsAsset = true;
                shopping.IsDeleted = false;
                shopping.IsDeletedAt = null;
                shopping.IsModifedShopping = DateTime.Now;
                shopping.IsModified = true;
                shopping.ShoppingStatus = 1;

                _db.Entry(_getShopping).State = EntityState.Modified;

                return IsSave();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsExisteShoppingById(int shoppingId)
        {
            try
            {
                return _db.Set<Shopping>().Any(e => e.ShoppingId == shoppingId);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }

        #endregion
    }
}
