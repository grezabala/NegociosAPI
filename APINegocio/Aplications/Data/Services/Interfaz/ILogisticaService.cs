using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface ILogisticaService
    {
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity)where T : class;
        Task<bool> SaveAll();
        bool LoadAll();

        //Customers
        Task<IEnumerable<Customers>> GetCliente();
        Task<Customers> GetCustomersByIdAsync(int Id);
        Task<Customers> GetCustomersByNameAsync(string names);
        Task<ICollection<Customers>> GetByCustomersByCodeAsync(string code);
        bool GetByCustomerIsDeleted(Customers customers);

       

        //Orders
        Task<IEnumerable<Orders>> GetOrders();
        Task<Orders> GetOrdersByIdAsync(int Id);
        Task<Orders> GetOrdersByNameAsync(string names);
        Task<Orders> GetOrdersByCodeAsync(string code);
        bool GetByOrderIsDeleted(Orders orders);

        //Senders
        Task<IEnumerable<Senders>> GetSenders();
        Task<Senders> GetSendersByIdAsync(int Id);
        Task<Senders> GetSendersByNameAsync(string names);
        Task<Senders> GetSendersByCodeAsync(string code);
        bool GetSenderByIsDeleted(Senders senders);

        //Payments
        Task<IEnumerable<Payments>> GetPayments();
        Task<Payments> GetPaymentsByIdAsync(int Id);
        Task<Payments> GetPaymentsByToquenAsync(string toquen);
        Task<Payments> GetPaymentsByCodeAsync(string code);
        bool GetByPaymentIsDeleted(Payments payments);

      
    }
}
