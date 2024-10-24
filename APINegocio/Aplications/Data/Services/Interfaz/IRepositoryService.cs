using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Interfaz
{
    public interface IRepositoryService
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        bool LoadAll();

        //Users
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUsersByIdAsync(int Id);
        Task<Users> GetUsersNameByAsync(string names);

        //Productos
        Task<IEnumerable<Productos>> GetProductos();
        Task<Productos> GetProductosByIdAsync(int Id);
        Task<ICollection<Productos>> GetProductosByNameAsync(string names);
        bool GetProductosByDeleted(Productos productos);

        //Parte proveedores
        Task<ICollection<Proveedores>> GetProveedoresByNameAsync(string names);
        Task<IEnumerable<Proveedores>> GetProveedores();
        Task<Proveedores> GetProveedoresByIdAsync(int Id);
        Task<ICollection< Proveedores>> GetByProveedorCodeAsync(string code);
        bool GetProveedorByIsDeleted(Proveedores proveedores);
    }
}
