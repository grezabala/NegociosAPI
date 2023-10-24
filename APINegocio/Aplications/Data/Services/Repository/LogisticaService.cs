using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Services.Interfaz.IContext;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APINegocio.Aplications.Services.Repository
{
    public class LogisticaService : ILogisticaService
    {

        private readonly APINegociosDbContext _Db;
        private readonly APINegociosDbContext _APINegociosDb;
        public LogisticaService(APINegociosDbContext dbContext)
        {
            _Db = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _Db.Add(entity);
        }
        public void Remove<T>(T entity) where T : class
        {
            _Db.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _Db.SaveChangesAsync() > 0;
        }

        #region CUSTOMER METHOD
        public async Task<IEnumerable<Customers>> GetCliente()
        {
            var getCustomer = await _Db.Customers.ToListAsync();
            return getCustomer;
        }

        public async Task<Customers> GetCustomersByIdAsync(int Id)
        {
            var getCustomerById = await _Db.Customers.FirstOrDefaultAsync(x => x.CustomerId == Id);
            return getCustomerById!;
        }

        public async Task<Customers> GetCustomersByNameAsync(string names)
        {
            var getCustomerByName = await _Db.Customers.FirstOrDefaultAsync(x => x.CustomerName == names);
            return getCustomerByName!;
        }
        #endregion

        #region SHOPPING METHOD
        public async Task<IEnumerable<Shopping>> GetShoppings()
        {
            var getShopping = await _Db.Shoppings.ToListAsync();
            return getShopping;
        }

        public async Task<Shopping> GetShoppingByIdAsync(int Id)
        {
            var getShoppingById = await _Db.Shoppings.FirstOrDefaultAsync(x => x.ShoppingId == Id);
            return getShoppingById!;
        }

        public async Task<Shopping> GetShoppingByNameAsync(string names)
        {
            var getShoppingByName = await _Db.Shoppings.FirstOrDefaultAsync(x => x.ShoppingName == names);
            return getShoppingByName!;
        }

        public async Task<Shopping> GetShoppingByNumberShopping(Shopping shopping)
        {
            var getShoppinByNumber = await _Db.Shoppings.FirstOrDefaultAsync(x => x.NumberShopping == shopping.NumberShopping);
            return getShoppinByNumber!;
        }

        public async Task<Shopping> GetShoppingByCodeAsync(Shopping shopping)
        {
            var getShoppinCode = await _Db.Shoppings.FirstOrDefaultAsync(x => x.ShoppingCode == shopping.ShoppingCode);
            return getShoppinCode!;
        }
        #endregion

        #region ORDERS METHOD
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            var getOrders = await _Db.Orders.ToListAsync();
            return getOrders;
        }

        public async Task<Orders> GetOrdersByIdAsync(int Id)
        {
            var getByIdOrder = await _Db.Orders.FirstOrDefaultAsync(x => x.OrderId == Id);
            return getByIdOrder!;
        }

        public async Task<Orders> GetOrdersByNameAsync(string names)
        {
            var getNameOrder = await _Db.Orders.FirstOrDefaultAsync(x => x.OrderName == names);
            return getNameOrder!;
        }

        public async Task<Orders> GetOrdersByCodeAsync(string code)
        {
            var getCodeOrder = await _Db.Orders.FirstOrDefaultAsync(x => x.OrderCode == code);
            return getCodeOrder!;
        }
        #endregion

        #region SENDERS METHOD
        public async Task<IEnumerable<Senders>> GetSenders()
        {
            var getSenders = await _Db.Senders.ToListAsync();
            return getSenders;
        }

        public async Task<Senders> GetSendersByIdAsync(int Id)
        {
            var getSendersById = await _Db.Senders.FirstOrDefaultAsync(x => x.SenderId == Id);
            return getSendersById!;
        }

        public async Task<Senders> GetSendersByNameAsync(string names)
        {
            var getSenderName = await _Db.Senders.FirstOrDefaultAsync(x => x.SenderName == names);
            return getSenderName!;
        }

        public async Task<Senders> GetSendersByCodeAsync(string code)
        {
            var getSenderCode = await _Db.Senders.FirstOrDefaultAsync(x => x.SenderCode == code);
            return getSenderCode!;
        }
        #endregion

        #region TICKER METHOD
        public async Task<IEnumerable<Tickers>> GetTickers()
        {
            var getTicker = await _Db.Tickers.ToListAsync();
            return getTicker;

        }

        public async Task<Tickers> GetTickersByIdAsync(int Id)
        {
            var getTickerById = await _Db.Tickers.FirstOrDefaultAsync(x => x.TickerId == Id);
            return getTickerById!;
        }

        public async Task<Tickers> GetTickersByNameAsync(string names)
        {
            var getTickerByName = await _Db.Tickers.FirstOrDefaultAsync(x => x.TickerTitulo == names);
            return getTickerByName!;
        }

        public async Task<Tickers> GetTickersByCodeAsync(string code)
        {
            var getTickerByCode = await _Db.Tickers.FirstOrDefaultAsync(x => x.CodeTicker == code);
            return getTickerByCode!;
        }
        #endregion

        #region PAYMENTS METHOD
        public async Task<IEnumerable<Payments>> GetPayments()
        {
            var getPayments = await _Db.Payments.ToListAsync();
            return getPayments;
        }

        public async Task<Payments> GetPaymentsByIdAsync(int Id)
        {
            var getByIdPayments = await _Db.Payments.FirstOrDefaultAsync(x => x.PaymentId == Id);
            return getByIdPayments!;
        }

        public async Task<Payments> GetPaymentsByToquenAsync(string toquen)
        {
            var getByIdToquen = await _Db.Payments.FirstOrDefaultAsync(x => x.Toquen == toquen);
            return getByIdToquen!;
        }
        #endregion

        #region INVENTORY METHOD
        public async Task<IEnumerable<Inventory>> GetInventoryAsync()
        {
            try
            {
                var getInventory = (from inv in _APINegociosDb.Inventory
                                    select inv).ToListAsync();

                return await getInventory;
            }
            catch (WebException ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<Inventory>> GetByIdInventory(int Id)
        {
            try
            {
                var getById = (from getId in _APINegociosDb.Inventory
                               where getId.InventoryId == Id
                               select getId).ToListAsync();

                return await getById;
            }
            catch (WebException ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<Inventory>> GetByCodeInventory(string code)
        {
            try
            {
                var getCode = _APINegociosDb.Inventory.Where(c => c.CodigoInventory.Any(char.IsLetterOrDigit) &&
                c.CodigoInventory.Contains(code)).ToListAsync();

                return await getCode;
            }
            catch (WebException ex)
            {

                throw ex;
            }

        }

        public async Task<IEnumerable<Inventory>> GetByNameInventory(string name)
        {
            try
            {
                var getByName = _APINegociosDb.Set<Inventory>().Where(e => e.InventoryName.Any(char.IsLetterOrDigit)
                && e.InventoryName.Contains(name)).ToListAsync();

                return await getByName;

                //var getByName = (from getName in _APINegociosDb.Inventory
                //                 where getName.InventoryName == name
                //                 select getName).ToListAsync();

                //return await getByName;
            }
            catch (WebException ex)
            {

                throw ex;
            }
        }
        public async Task<IEnumerable<Inventory>> GetByNumberInventories(int number)
        {
            try
            {
                // var getByNumber = _APINegociosDb.Set<Inventory>().Where(e => e.NumberInventory.Any(char.IsLetterOrDigit)
                //&& e.NumberInventory.Contains(number))

                var getNumber = (from num in _APINegociosDb.Inventory
                                 where num.NumberInventory == number
                                 select num).ToListAsync();

                return await getNumber;
            }
            catch (WebException ex)
            {

                throw ex;
            }

        }
        #endregion
    }
}
