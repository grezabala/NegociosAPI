using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface IShoppingService
    {
        //Shopping
        Task<ICollection<Shopping>> GetShoppings();
        Task<Shopping> GetShoppingByIdAsync(int Id);
        Task<ICollection<Shopping>> GetShoppingByNameAsync(string names);
        Task<Shopping> GetShoppingByNumberShopping(int number);
        Task<ICollection<Shopping>> GetShoppingByCodeAsync(string code);
        bool GetShoppingByIsDeleted(Shopping shopping);
        bool IsCread(Shopping cread);
        bool IsUpdated(Shopping shopping);
        bool IsExisteShoppingByName(string name);
        bool IsExisteShoppingByCode(string code);
        bool IsExisteShoppingById(int shoppingId);
        bool IsSave();
    }
}
