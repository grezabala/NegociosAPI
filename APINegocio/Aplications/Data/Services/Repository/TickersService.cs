using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class TickersService : ITickersService
    {
        private readonly APINegociosDbContext _db;

        public TickersService(APINegociosDbContext aPINegociosDbContext)
        {
            _db = aPINegociosDbContext;    
        }

        public async Task<ICollection<Tickers>> GetByTickersDateAsync(DateTime date)
        {
            try
            {
                return await _db.Tickers
                    .Where(x => x.CreationDate == date.Date)
                    .OrderBy(x => x.TickerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay Ticker emitido con esa fecha, verifique el Ticker con el ID, NIF, RNC, Código..."
                    + "O verifique que la fecha es correcta", ex);
            }
        }

        public bool GetByTickersIsDeleted(Tickers senders)
        {
            try
            {
                var _getTickerIsDeleted = _db.Tickers.Find(senders.TickerId);

                if (_getTickerIsDeleted != null)
                {
                    _getTickerIsDeleted.IsDeleted = true;
                    _getTickerIsDeleted.IsLocked = false;
                    _getTickerIsDeleted.IsStatus = false;
                    _getTickerIsDeleted.IsDeletedAt = DateTime.Now;

                     _db.SaveChanges();
                }

                return IsSaveAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No fue posible eliminar el Ticker, verificar que el ID sea correcto", ex);
            }
        }

        public async Task<ICollection<Tickers>> GetByTickersNIFAsync(int TickerNIF)
        {
            try
            {
                return await _db.Tickers
                    .OrderBy(e => e.NIF)
                    .AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay Ticker emitido con ese NIF, por favor verique el NIF esta correcto." +
                    "Intente buscar el Ticker por ID, RNC, o por el Código ", ex);
            }
        }

        public async Task<ICollection<Tickers>> GetByTickersRNCAsync(int TickerRNC)
        {
            try
            {

                return await _db.Set<Tickers>().OrderBy(e => e.RNC).AsTracking().ToListAsync();
                    
                //var _getRNC = _db.Tickers.FindAsync(TickerRNC);
                //if (await _getRNC != null)
                //{
                //    return await _db.Tickers
                //          .OrderBy(e => e.RNC)
                //          .AsNoTracking().ToListAsync();

                //}
                //return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay Ticker emitido con ese RNC, por favor verique el RNC esta correcto." +
                    "Intente buscar el Ticker por ID, NIF, o por el Código ", ex);
            }
        }

        public async Task<IEnumerable<Tickers>> GetTickers()
        {
            try
            {
                return await _db.Tickers.OrderBy(e => e.TransactionNumber)
                    .AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No se encontro ningún Tickes emitidos", ex);
            }
        }

        public async Task<ICollection<Tickers>> GetTickersByCodeAsync(string code)
        {
            try
            {
                IQueryable<Tickers> query = _db.Set<Tickers>();
                if (!string.IsNullOrEmpty(code))
                    query = query.Where(e => e.CodeTicker.ToLower().Trim() == code.ToLower().Trim());

                return await query.AsNoTracking().ToListAsync();


            }
            catch (Exception ex)
            {

                throw new Exception("Error...!",ex);
            }
        }

        public Tickers GetTickersById(int Id)
        {
            try
            {
                var _getTickerId = _db.Tickers.Find(Id);
                if (_getTickerId != null)
                {
                    return _db.Tickers.FirstOrDefault(e => e.TickerId == Id);

                }

                return new Tickers();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No hay se ha emitido ningún Ticker con el ID indicado, verifique que el ID sea correcto", ex);
            }
        }

        public async Task<ICollection<Tickers>> GetTickersByNameAsync(string names)
        {
            try
            {
                IQueryable<Tickers> query = _db.Set<Tickers>();
                if (!string.IsNullOrEmpty(names))
                    query = query.Where(e => e.CashierName.ToLower().Trim() == names.ToLower().Trim());

                return await query.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! No hay Ticker emitido con el nombre del colaborador, por favor verique el nombre esta correcto. " +
                    "Intente buscar el Ticker por ID, RNC, NIF o por el Código ", ex);
            }
        }

        public bool IsCreadAsync(Tickers tickers)
        {
            try
            {
                if (tickers != null)
                {
                    tickers.CreationDate = DateTime.Now;
                    tickers.IsStatus = true;
                    tickers.IsLocked = false;
                    tickers.IsDeleted = false;
                    tickers.IsModified = false;
                    tickers.IsModifiedDate = null;
                    tickers.NIF = new Random().Next();
                    tickers.RNC = new Random().Next();

                    _db.Add(tickers);
                    return IsSaveAll();
                }

                throw new InvalidOperationException("Error!!! No fue posible crear el nuevo Ticker:  El Ticker, no puede ser emitido vacio");

            }
            catch (Exception ex)
            {

                throw new Exception("Error! Algo salio mal al crear el Ticker", ex);
            }
        }

        public bool IsExisteByTickersCode(string Code)
        {
            try
            {
                if (Code != null)
                {
                    bool _respuestaCode = _db.Tickers.Any(e => e.CodeTicker.ToLower().Trim() == Code.ToLower().Trim());
                    return _respuestaCode;

                }
                throw new InvalidOperationException("Error! Algo salio mal al validar si el Ticker existe, mediante el código");
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salio mal al validar si el Ticker existe, mediante el código", ex);
            }
        }

        public bool IsExisteByTickersId(int Id)
        {
            try
            {
                return _db.Tickers.Any(e => e.TickerId == Id);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salio mal al validar si el Ticker existe, mediante el ID", ex);
            }
        }

        public bool IsExisteByTickersName(string Name)
        {
            try
            {
                if (Name != null)
                {
                    bool _respuestaName = _db.Tickers.Any(e => e.CashierName.ToLower().Trim() == Name.ToLower().Trim());
                    return _respuestaName;

                }
                throw new InvalidOperationException("Error! Algo salio mal al validar si el Ticker existe, mediante el nombre del colaborador o colaboradora");
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salio mal al validar si el Ticker existe, mediante el nombre del colaborador o colaboradora", ex);
            }
        }

        public bool IsExisteByTickersNIF(int NIF)
        {
            try
            {
                return _db.Set<Tickers>().Any(e => e.NIF == NIF);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salio mal al validar si el Ticker existe, mediante el NIF", ex);
            }
        }

        public bool IsExisteByTickersRNC(int rnc)
        {
            try
            {
                return _db.Set<Tickers>().Any(e => e.RNC == rnc);
            }
            catch (Exception ex)
            {

                throw new Exception("Error!!! Algo salio mal al validar si el Ticker existe, mediante el RNC", ex);
            }
        }

        public bool IsSaveAll()
        {
            try
            {
                return _db.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error....!", ex);
            }
        }

        public bool IsUpdated(Tickers tickers)
        {
            try
            {
                var _updatedTicker = GetTickersById(tickers.TickerId) ??
                    throw new ArgumentNullException("Error! No se encontro ningún registro con ID suministrado");

                if (_updatedTicker != null)
                {

                    _updatedTicker.TickerId = tickers.TickerId;
                    _updatedTicker.CustomerId = tickers.CustomerId;
                    _updatedTicker.TickerTitulo = tickers.TickerTitulo;
                    _updatedTicker.Pago = tickers.Pago;
                    _updatedTicker.CashierName = tickers.CashierName;
                    _updatedTicker.Direction = tickers.Direction;
                    _updatedTicker.RNC = tickers.RNC;
                    _updatedTicker.NIF = tickers.NIF;
                    _updatedTicker.TotalAmountItbis = tickers.TotalAmountItbis;
                    _updatedTicker.TotalAmountPay = tickers.TotalAmountPay;
                    _updatedTicker.TotalProduct = tickers.TotalProduct;
                    _updatedTicker.Description = tickers.Description;
                    _updatedTicker.TransactionNumber = tickers.TransactionNumber;
                    _updatedTicker.CodeTicker = tickers.CodeTicker;
                    _updatedTicker.CodeTicker = tickers.CodeTicker;

                    tickers.IsStatus = true;
                    tickers.IsDeleted = false;
                    tickers.IsLocked = true;
                    tickers.IsModified = true;
                    tickers.IsModifiedDate = DateTime.Now;
                    tickers.IsDeletedAt = null;
                    tickers.DateImprect = null;

                    _db.Entry(_updatedTicker).State = EntityState.Modified;
                    return IsSaveAll();

                }

                throw new InvalidOperationException("Error! No sé encontro ningún registro");

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible modificar el Ticker", ex);
            }
        }


        #region TICKER METHOD
        //public async Task<IEnumerable<Tickers>> GetTickers()
        //{
        //    var getTicker = await _Db.Tickers.ToListAsync();
        //    return getTicker;

        //}

        //public async Task<ICollection<Tickers>> GetByTickersNIFAsync(int TickerNIF)
        //{
        //    try
        //    {
        //        IQueryable<Tickers> query = _Db.Set<Tickers>();
        //        if (TickerNIF > 0)
        //            query = query.Where(e => e.NIF == TickerNIF).OrderBy(e => e.TickerId);

        //        return await query.ToListAsync();

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error! El NIF ingresado no existe, ningún Ticke fue emitido con ese NIF", ex);
        //    }
        //}

        //public async Task<ICollection<Tickers>> GetByTickersRNCAsync(int TickerRNC)
        //{
        //    try
        //    {
        //        IQueryable<Tickers> query = _Db.Set<Tickers>();
        //        if (TickerRNC > 0)
        //            query = query.Where(e => e.RNC == TickerRNC).OrderBy(e => e.TickerId);

        //        return await query.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error! El RNC ingresado no existe, ningún Ticke fue emitido con ese RNC", ex);
        //    }
        //}


        //public async Task<ICollection<Tickers>> GetByTickersDateAsync(DateTime date)
        //{
        //    try
        //    {

        //        IQueryable<Tickers> query = _Db.Set<Tickers>();
        //        query = query.Where(e => e.CreationDate == date.AddDays(-1)).OrderBy(e => e.CreationDate);

        //        return await query.ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error! El día que indica no hay ningún Ticke emitido", ex);
        //    }
        //}

        //public async Task<Tickers> GetTickersByIdAsync(int Id)
        //{
        //    var getTickerById = await _Db.Tickers.FirstOrDefaultAsync(x => x.TickerId == Id);
        //    return getTickerById!;
        //}

        //public async Task<Tickers> GetTickersByNameAsync(string names)
        //{
        //    var getTickerByName = await _Db.Tickers.FirstOrDefaultAsync(x => x.TickerTitulo == names);
        //    return getTickerByName!;
        //}

        //public async Task<Tickers> GetTickersByCodeAsync(string code)
        //{
        //    var getTickerByCode = await _Db.Tickers.FirstOrDefaultAsync(x => x.CodeTicker == code);
        //    return getTickerByCode!;
        //}


        #endregion

    }
}
