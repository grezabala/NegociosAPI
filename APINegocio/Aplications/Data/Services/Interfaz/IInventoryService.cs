using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface IInventoryService
    {
        Task<ICollection<Inventory>> GetInventoryAsync();
        Task<Inventory> GetByInventoryId(int Id);
        Task<ICollection<Inventory>> GetByCodeInventory(string code);
        Task<ICollection<Inventory>> GetByInventoryName(string name);
        Task<Inventory> GetByInventoriesNumber(int number);
        bool IsCread(Inventory cread);
        Task<bool> IsUpdated(Inventory updated);
        Task<bool> IsDeleted(Inventory deleted);
        bool IsExisteGetInventarioByNumber(int number);
        bool IsExisteGetInventarioByCode(string code);
        bool IsSaveAll();
    }
}
