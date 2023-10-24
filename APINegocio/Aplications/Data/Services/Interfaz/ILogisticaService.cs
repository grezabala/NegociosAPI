using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface ILogisticaService
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity)where T : class;
        Task<bool> SaveAll();

        //Customers
        Task<IEnumerable<Customers>> GetCliente();
        Task<Customers> GetCustomersByIdAsync(int Id);
        Task<Customers> GetCustomersByNameAsync(string names);

        //Shopping
        Task<IEnumerable<Shopping>> GetShoppings();
        Task<Shopping> GetShoppingByIdAsync(int Id);
        Task<Shopping> GetShoppingByNameAsync(string names);
        Task<Shopping> GetShoppingByNumberShopping(Shopping shopping);
        Task<Shopping> GetShoppingByCodeAsync(Shopping shopping);

        //Orders
        Task<IEnumerable<Orders>> GetOrders();
        Task<Orders> GetOrdersByIdAsync(int Id);
        Task<Orders> GetOrdersByNameAsync(string names);
        Task<Orders> GetOrdersByCodeAsync(string code);

        //Senders
        Task<IEnumerable<Senders>> GetSenders();
        Task<Senders> GetSendersByIdAsync(int Id);
        Task<Senders> GetSendersByNameAsync(string names);
        Task<Senders> GetSendersByCodeAsync(string code);

        //Tickers
        Task<IEnumerable<Tickers>> GetTickers();
        Task<Tickers> GetTickersByIdAsync(int Id);
        Task<Tickers> GetTickersByNameAsync(string names);
        Task<Tickers> GetTickersByCodeAsync(string code);

        //Payments
        Task<IEnumerable<Payments>> GetPayments();
        Task<Payments> GetPaymentsByIdAsync(int Id);
        Task<Payments> GetPaymentsByToquenAsync(string toquen);

        //INVENTORY
        Task<IEnumerable<Inventory>> GetInventoryAsync();
        Task<IEnumerable<Inventory>> GetByIdInventory(int Id);
        Task<IEnumerable<Inventory>> GetByCodeInventory(string code);
        Task<IEnumerable<Inventory>> GetByNameInventory(string name);
        Task<IEnumerable<Inventory>> GetByNumberInventories(int number);    
    }
}
