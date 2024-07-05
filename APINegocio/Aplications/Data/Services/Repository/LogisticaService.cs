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

        private readonly APINegociosDbContext _db;
        //private readonly APINegociosDbContext _APINegociosDb;
        public LogisticaService(APINegociosDbContext dbContext)
        {
            _db = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _db.Add(entity);
        }
        public void Remove<T>(T entity) where T : class
        {
            _db.Remove(entity);
        }

        public bool LoadAll()
        {
            try
            {
                return _db.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No fue posible cargar el registro", ex);
            }
        }

        public async Task<bool> SaveAll()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        #region CUSTOMER METHOD


        public async Task<bool> IsCread(Customers customers)
        {
            try
            {
                if (customers != null)
                {
                    customers.IsDeleted = false;
                    customers.IsDeletedAt = null;
                    customers.IsStatu = true;
                    customers.IsUpdatedDate = null;
                    customers.CreatedDate = DateTime.Now;
                    customers.IsModified = false;

                    await _db.Set<Customers>().AddAsync(customers);
                    return await SaveAll();


                }
                throw new InvalidOperationException("El formulario se envio vacio.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al registrar el nuevo cliente.", ex);
            }
        }

        public async Task<bool> IsUpdated(Customers customers)
        {
            try
            {
                var _customerUpdated = await GetCustomersByIdAsync(customers.CustomerId) ?? throw new ArgumentNullException("No se ingreso el ID.");

                _customerUpdated.CustomerId = customers.CustomerId;
                _customerUpdated.CustomerName = customers.CustomerName;
                _customerUpdated.CustomerEmail = customers.CustomerEmail;
                _customerUpdated.CustomerPhone = customers.CustomerPhone;
                _customerUpdated.Direction = customers.Direction;
                _customerUpdated.City = customers.City;
                _customerUpdated.PostalCode = customers.PostalCode;
                _customerUpdated.Country = customers.Country;
                _customerUpdated.CreatedDate = customers.CreatedDate;
                _customerUpdated.CodeCustomer = customers.CodeCustomer;

                customers.IsUpdatedDate = DateTime.Now;
                customers.IsDeleted = false;
                customers.IsStatu = true;
                customers.IsModified = true;
                customers.IsDeletedAt = null;

                _db.Entry(_customerUpdated).State = EntityState.Modified;
                return await SaveAll();

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al modificar el cliente.", ex);
            }
        }


        public async Task<IEnumerable<Customers>> GetCliente()
        {
            try
            {
                var getCustomer = await _db.Set<Customers>().OrderBy(x => x.CustomerId)
                    .AsNoTracking()
                    .ToListAsync();

                return getCustomer;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        public async Task<Customers> GetCustomersByIdAsync(int Id)
        {
            try
            {
                return await _db.Customers.FirstOrDefaultAsync(x => x.CustomerId == Id);

            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        public async Task<ICollection<Customers>> GetCustomersByNameAsync(string names)
        {
            try
            {
                IQueryable<Customers> query = _db.Set<Customers>();
                if (!string.IsNullOrEmpty(names))
                    query = query.Where(x => x.CustomerName.Contains(names.ToLower().Trim()) || x.CustomerName.Contains(names.ToLower().Trim()));

                return await query.OrderBy(x => x.CustomerName).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        public async Task<ICollection<Customers>> GetByCustomersByCodeAsync(string code)
        {
            try
            {
                if (code != null)
                {
                    IQueryable<Customers> query = _db.Set<Customers>();
                    if (!string.IsNullOrEmpty(code))
                        query = query.Where(e => e.CodeCustomer.Contains(code.ToLower().Trim()) || e.CodeCustomer.Contains(code.ToLower().Trim()));

                    return await query.AsNoTracking().ToListAsync();

                }

                return new List<Customers>();

                //var _getCustomerByCode = await _Db.Customers.FindAsync(code).;
                //return _getCustomerByCode;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No se encontro ningún cliente asociado a ese código postal", ex);
            }
        }

        public async Task<ICollection<Customers>> GetByCustomersByCodePostalAsync(string codePostal)
        {
            try
            {
                if (codePostal != null)
                {
                    IQueryable<Customers> query = _db.Set<Customers>();
                    if (!string.IsNullOrEmpty(codePostal))
                        query = query.Where(e => e.PostalCode.Contains(codePostal.ToLower().Trim()) || e.PostalCode.Contains(codePostal.ToLower().Trim()));

                    return await query.AsNoTracking().ToListAsync();

                }

                return new List<Customers>();

                //var _getCustomerByCode = await _Db.Customers.FindAsync(code).;
                //return _getCustomerByCode;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No se encontro ningún cliente asociado a ese código postal", ex);
            }
        }

        public bool GetByCustomerIsDeleted(Customers customers)
        {
            try
            {
                var _getIsDeleted = _db.Customers.Find(customers.CustomerId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsStatu = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;
                    _db.SaveChanges();
                }

                return LoadAll();

            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salió mal al eliminar el registro", ex);
            }
        }

        #endregion

        #region ORDERS METHOD
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            try
            {
                var getOrders = await _db.Orders.ToListAsync();
                return getOrders;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar todas las Ordenes.", ex);
            }

        }

        public async Task<Orders> GetOrdersByIdAsync(int Id)
        {
            try
            {
                var getByIdOrder = await _db.Orders.FirstOrDefaultAsync(x => x.OrderId == Id);
                return getByIdOrder!;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posiblie mostrar la Order, por favor validar que el ID sea el correcto.", ex);
            }

        }

        public async Task<Orders> GetOrdersByNameAsync(string names)
        {
            try
            {
                var getNameOrder = await _db.Orders.FirstOrDefaultAsync(x => x.OrderName == names);
                return getNameOrder!;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posiblie mostrar la Order, por favor validar que el nombre sea el correcto.", ex);
            }

        }

        public async Task<Orders> GetOrdersByCodeAsync(string code)
        {
            try
            {
                var getCodeOrder = await _db.Orders.FirstOrDefaultAsync(x => x.OrderCode == code);
                return getCodeOrder!;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posiblie mostrar la Order, por favor validar que el código sea el correcto.", ex);
            }

        }

        public bool GetByOrderIsDeleted(Orders orders)
        {
            try
            {
                var _getIsDeleted = _db.Set<Orders>().Find(orders.OrderId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsAsset = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;
                    _db.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posiblie eliminar la Order, por favor validar que el ID sea el correcto.", ex);
            }
        }
        #endregion

        #region SENDERS METHOD
        public async Task<IEnumerable<Senders>> GetSenders()
        {
            try
            {
                var getSenders = await _db.Set<Senders>()
                    .OrderBy(e => e.SenderName)
                    .AsNoTracking()
                    .ToListAsync();

                return getSenders;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar todos los remitentes.", ex);
            }

        }

        public async Task<Senders> GetSendersByIdAsync(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var getSendersById = await _db.Senders.FirstOrDefaultAsync(x => x.SenderId == Id);
                    return getSendersById!;

                }
                throw new InvalidOperationException("Error...! El ID no fue ingresado.");

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el remitentes. Por favor validar que el ID sea el correcto. " +
                    "O que el remitente existe.", ex);
            }

        }

        public async Task<Senders> GetSendersByNameAsync(string names)
        {
            try
            {
                if (names != null)
                {
                    var getSenderName = await _db.Senders.FirstOrDefaultAsync(x => x.SenderName == names);
                    return getSenderName!;

                }
                throw new InvalidOperationException("Error...! El nombre no fue ingresado.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el remitentes. Por favor validar que el nombre sea el correcto. " +
                    "O que el remitente existe.", ex);
            }

        }

        public async Task<Senders> GetSendersByCodeAsync(string code)
        {
            try
            {
                if (code != null)
                {

                    var getSenderCode = await _db.Senders.FirstOrDefaultAsync(x => x.SenderCode == code);
                    return getSenderCode!;
                }
                throw new InvalidOperationException("Error...! El código no fue ingresado.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al mostrar el remitentes. Por favor validar que el código sea el correcto. " +
                   "O que el remitente existe.", ex);
            }

        }

        public bool GetSenderByIsDeleted(Senders senders)
        {
            try
            {
                var _getSenderIsDeleted = _db.Set<Senders>().Find(senders.SenderId);
                if (_getSenderIsDeleted != null)
                {

                    _getSenderIsDeleted.IsDeleted = true;
                    _getSenderIsDeleted.IsAsset = false;
                    _getSenderIsDeleted.IsDeletedAt = DateTime.Now;
                    _db.SaveChanges();

                }
                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al eliminar el registro, por favor validar que el ID, sea el correcto.", ex);
            }
        }
        #endregion

        #region PAYMENTS METHOD
        public async Task<IEnumerable<Payments>> GetPayments()
        {
            try
            {
                return await _db.Set<Payments>().OrderBy(e => e.OrderId).ToListAsync();

                //var getPayments = await _db.Payments.ToListAsync();
                //return getPayments;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar los pagos", ex);
            }

        }

        public async Task<Payments> GetPaymentsByIdAsync(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var getByIdPayments = await _db.Payments.FirstOrDefaultAsync(x => x.PaymentId == Id);
                    return getByIdPayments!;
                }
                throw new InvalidOperationException("No fue posible mostrar el pago");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible el pago", ex);
            }

        }

        public async Task<Payments> GetPaymentsByToquenAsync(string toquen)
        {
            try
            {
                if (toquen != null)
                {
                    var getByIdToquen = await _db.Payments.FirstOrDefaultAsync(x => x.Toquen == toquen);
                    return getByIdToquen!;

                }
                throw new InvalidOperationException("No fue posible a mostrar el pago por el toquen");

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el pago", ex);
            }

        }
        public async Task<Payments> GetPaymentsByCodeAsync(string code)
        {
            try
            {
                if (code != null)
                {
                    var _get = await _db.Set<Payments>().OrderBy(e => e.PaymentCode).FirstOrDefaultAsync(e => e.PaymentCode == code);
                    return _get;

                }
                throw new InvalidOperationException("Error...! No sé encontro ningún pago");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el pago, por favor validar que el código, sea el correcto", ex);
            }
        }

        public bool GetByPaymentIsDeleted(Payments payments)
        {
            try
            {
                var _get = _db.Set<Payments>().Find(payments.PaymentId);
                if (_get != null)
                {
                    _get.IsDeleted = true;
                    _get.IsDeletedAt = DateTime.Now;
                    _get.IsUpdatedAt = null;
                    _get.IsStatud = false;
                    _get.IsRefund = false;
                    _db.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible eliminar el pago.", ex);
            }
        }

        #endregion

    }
}
