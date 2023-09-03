using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services
{
    public interface IProveedoresService
    {
        Task<Proveedores> Add(Proveedores model);
        Task<Proveedores> Update(int Id, Proveedores model);
        Task Deleted(int Id);
        Task<IEnumerable<Proveedores>> Get();
        Task<Proveedores> Get(int Id);
    }
}
