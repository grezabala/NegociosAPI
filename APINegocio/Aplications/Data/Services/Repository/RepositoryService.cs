using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Interfaz;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APINegocio.Aplications.Services.Repository
{
    public class RepositoryService : IRepositoryService
    {
        public readonly APINegociosDbContext _APINegocioDbContext;

        public RepositoryService(APINegociosDbContext aPINegocioDbContext)
        {
            _APINegocioDbContext = aPINegocioDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _APINegocioDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _APINegocioDbContext.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _APINegocioDbContext.SaveChangesAsync() > 0;
        }

        #region METODOS PRODUCTOS

        public async Task<IEnumerable<Productos>> GetProductos()
        {
            var getProducto = await _APINegocioDbContext.Productos.ToListAsync();
            return getProducto;
        }

        public async Task<Productos> GetProductosByIdAsync(int Id)
        {
            var getByIdProducto = await _APINegocioDbContext.Productos.FirstOrDefaultAsync(e => e.ProductId == Id);
            return getByIdProducto!;
        }

        public async Task<Productos> GetProductosByNameAsync(string names)
        {
            var getNameProducto = await _APINegocioDbContext.Productos.FirstOrDefaultAsync(x => x.ProductName == names);
                
            return getNameProducto!;
        }
        #endregion

        #region METODOS PROVEEDORES
        public async Task<IEnumerable<Proveedores>> GetProveedores()
        {
            var getProveedores = await _APINegocioDbContext.Proveedores.ToListAsync();
            return getProveedores;
        }

        public async Task<Proveedores> GetProveedoresByIdAsync(int Id)
        {
            var getByIdProveedores = await _APINegocioDbContext.Proveedores.FirstOrDefaultAsync(x => x.ProveedorId == Id);
            return getByIdProveedores;
        }

        public async Task<Proveedores> GetProveedoresByNameAsync(string names)
        {
            var getNameProveedores = await _APINegocioDbContext.Proveedores.FirstOrDefaultAsync(x => x.ProveedorName == names);
            return getNameProveedores;
        }
        #endregion

        #region MEDOTOS USERS
        public async Task<IEnumerable<Users>> GetUsers()
        {
            var getUser = await _APINegocioDbContext.Users.ToListAsync();
            return getUser;
        }

        public async Task<Users> GetUsersByIdAsync(int Id)
        {
            var getByIdUser = await _APINegocioDbContext.Users.FirstOrDefaultAsync(e => e.UserId == Id);
            return getByIdUser;
        }

        public async Task<Users> GetUsersNameByAsync(string names)
        {
            var getNameUser = await _APINegocioDbContext.Users.FirstOrDefaultAsync(e => e.UserName == names);
            return getNameUser;
        }
        #endregion

    }
}
