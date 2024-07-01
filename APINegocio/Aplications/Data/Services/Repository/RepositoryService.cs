using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Interfaz;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APINegocio.Aplications.Services.Repository
{
    public class RepositoryService : IRepositoryService
    {
        public readonly APINegociosDbContext _dbContext;

        public RepositoryService(APINegociosDbContext aPINegocioDbContext)
        {
            _dbContext = aPINegocioDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        #region METODOS PRODUCTOS

        public async Task<IEnumerable<Productos>> GetProductos()
        {
            try
            {
                return await _dbContext.Set<Productos>().OrderBy(e => e.ProductId)
                    .AsNoTracking()
                    .ToListAsync();

                //var getProducto = await _dbContext.Productos.ToListAsync();
                //return getProducto;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar todos los productos.", ex);
            }

        }

        public async Task<Productos> GetProductosByIdAsync(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var getByIdProducto = await _dbContext.Productos.FirstOrDefaultAsync(e => e.ProductId == Id);
                    return getByIdProducto!;
                }
                throw new InvalidOperationException("Error...! No se indico el ID");

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el productos. Por favor validar que el ID sea el correcto.", ex);
            }

        }

        public async Task<Productos> GetProductosByNameAsync(string names)
        {
            try
            {
                if (names != null)
                {
                    var getNameProducto = await _dbContext.Productos.FirstOrDefaultAsync(x => x.ProductName == names);
                    return getNameProducto!;
                }
                throw new InvalidOperationException("Error...! No se indico el nombre del producto");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el productos. Por favor validar que el ID sea el correcto.", ex);
            }

        }

        public bool LoadAll()
        {
            try
            {
                return _dbContext.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible cargar el registro.", ex);
            }
        }

        public bool GetProductosByDeleted(Productos productos)
        {
            try
            {
                var _get = _dbContext.Set<Productos>().Find(productos.ProductId);
                if (_get != null)
                {
                    _get.IsDeleted = true;
                    _get.IsDeletedAt = DateTime.Now;
                    _get.IsAsset = false;
                    _dbContext.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible eliminar el producto, el ID ingresado no coicide con ningún producto.", ex);
            }
        }

        #endregion

        #region METODOS PROVEEDORES
        public async Task<IEnumerable<Proveedores>> GetProveedores()
        {
            try
            {
                var getProveedores = await _dbContext.Set<Proveedores>().OrderBy(e => e.ProveedorName)
                                .AsNoTracking()
                                .ToListAsync();

                return getProveedores;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar todos los proveedores.", ex);
            }

        }

        public async Task<Proveedores> GetProveedoresByIdAsync(int Id)
        {
            try
            {
                var getByIdProveedores = await _dbContext.Proveedores.FirstOrDefaultAsync(x => x.ProveedorId == Id);
                return getByIdProveedores;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el registro, por favor verificar que el ID sea el correcto. " +
                    "O que el registro existe", ex);
            }

        }

        public async Task<Proveedores> GetProveedoresByNameAsync(string names)
        {
            try
            {
                var getNameProveedores = await _dbContext.Proveedores.FirstOrDefaultAsync(x => x.ProveedorName == names);
                return getNameProveedores;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el registro, por favor verificar que el nombre sea el correcto. " +
                    "O que el registro existe", ex);
            }

        }

        public async Task<ICollection<Proveedores>> GetByProveedorCodeAsync(string code)
        {
            try
            {
                IQueryable<Proveedores> query = _dbContext.Set<Proveedores>();
                if (!string.IsNullOrEmpty(code))
                    query = query.Where(e => e.ProveedorCode.Contains(code.Trim()) || e.ProveedorCode.Contains(code.Trim()));

                return await query
                    .AsNoTracking()
                    .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Error!... No fue posible encontrar el Código", ex);
            }
        }

        public bool GetProveedorByIsDeleted(Proveedores proveedores)
        {
            try
            {
                var _get = _dbContext.Set<Proveedores>().Find(proveedores.ProveedorId);
                if (_get != null)
                {
                    _get.IsDeleted = true;
                    _get.IsAsset = false;
                    _get.IsDeletedAt = DateTime.Now;
                    _dbContext.SaveChanges();
                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible eliminar el registro, por favor verificar que el ID sea el correcto. "
                    + "O si el registro existe.", ex);
            }
        }

        #endregion

        #region MEDOTOS USERS
        public async Task<IEnumerable<Users>> GetUsers()
        {
            var getUser = await _dbContext.Users.ToListAsync();
            return getUser;
        }

        public async Task<Users> GetUsersByIdAsync(int Id)
        {
            var getByIdUser = await _dbContext.Users.FirstOrDefaultAsync(e => e.UserId == Id);
            return getByIdUser;
        }

        public async Task<Users> GetUsersNameByAsync(string names)
        {
            var getNameUser = await _dbContext.Users.FirstOrDefaultAsync(e => e.UserName == names);
            return getNameUser;
        }



        #endregion

    }
}
