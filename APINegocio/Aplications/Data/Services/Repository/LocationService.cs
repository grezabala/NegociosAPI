using APINegocio.Aplications.Data.ContextDB;
using APINegocio.Aplications.Data.Services.Interfaz;
using APINegocio.Aplications.Entities;
using APINegocio.Aplications.Services.Interfaz.IContext;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace APINegocio.Aplications.Data.Services.Repository
{
    public class LocationService : ILocationService
    {

        private readonly APINegociosDbContext _aPINegociosDb;

        public LocationService(APINegociosDbContext aPINegocioDbContext) => _aPINegociosDb = aPINegocioDbContext;

        public void Add<TEntitie>(TEntitie entitie) where TEntitie : class
        {
            _aPINegociosDb.Add(entitie);
        }
        public void Remove<TEntitie>(TEntitie entitie) where TEntitie : class
        {
            _aPINegociosDb.Remove(entitie);
        }

        public async Task<bool> SaveAll()
        {
            return await _aPINegociosDb.SaveChangesAsync() > 0;
        }

        public bool LoadAll()
        {
            try
            {
                return _aPINegociosDb.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fué posible cargar el registro eliminado", ex);

            }
        }


        #region CITY METODH

        public async Task<bool> IsCread(City city)
        {
            try
            {
                if (city != null)
                {
                    city.IsDeletedAt = null;
                    city.IsUpdateAt = null;
                    city.IsUpdated = false;
                    city.IsDeleted = false;
                    city.IsStatus = true;

                    _aPINegociosDb.Add(city);
                    return await SaveAll();


                }
                throw new InvalidOperationException("Error...! El formulario llego vacio.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al registrar la ciudad.", ex);
            }


        }
        public async Task<bool> IsUpdated(City city)
        {
            try
            {

                var _updated = GetByIdCityAsync(city.CityId).Result ?? throw new ArgumentNullException("Error! El Id ingresado no esta registrado a ninguna Ciudad.");

                _updated.CityId = city.CityId;
                _updated.Code = city.Code;
                _updated.CityName = city.CityName;

                city.IsUpdated = true;
                city.IsUpdateAt = DateTime.Now;
                city.IsDeletedAt = null;
                city.IsDeleted = false;
                city.IsStatus = true;

                _aPINegociosDb.Entry(_updated).State = EntityState.Modified;
                return await SaveAll();

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al editar el registro.", ex);
            }

        }

        public async Task<City> GetByCodeCityAsync(string code)
        {
            try
            {
                if (code != null)
                {
                    return await _aPINegociosDb.Set<City>().OrderBy(x => x.Code).FirstOrDefaultAsync(x => x.Code == code);

                }
                throw new InvalidOperationException("No se indico el código");

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el registro solicitado. Por favor verificar que el código, sea el correcto.", ex);
            }

        }

        public async Task<City> GetByIdCityAsync(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    return await _aPINegociosDb.Set<City>().OrderBy(x => x.CityId).FirstOrDefaultAsync(x => x.CityId == Id);
                }
                throw new InvalidOperationException("No se indico el ID");

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el registro solicitado. Por favor verificar que el ID, sea el correcto.", ex);
            }

        }

        public async Task<ICollection<City>> GetByNameCityAsync(string names)
        {
            try
            {

                IQueryable<City> query = _aPINegociosDb.Set<City>();
                if (!string.IsNullOrEmpty(names))
                    query = query.Where(x => x.CityName.Contains(names) || x.Code.Contains(names));

                return await query.AsNoTracking().ToListAsync();

                //if (names != null)
                //{
                //    return await _APINegociosDb.Set<City>().OrderBy(x => x.CityName).FirstOrDefaultAsync(x => x.CityName == names);
                //}
                //throw new InvalidOperationException("No se indico el nombre");

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el registro solicitado. Por favor verificar que el nombre, sea el correcto.", ex);
            }

        }

        public async Task<IEnumerable<City>> GetCitys()
        {
            try
            {
                return await _aPINegociosDb.Set<City>().OrderBy(e => e.CityName)
                   .AsNoTracking()
                   .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible mostrar el registro solicitado.", ex);
            }

        }

        public bool GetByCityIsDeleted(City city)
        {
            try
            {
                var _IsDeletedCity = _aPINegociosDb.Set<City>().Find(city.CityId);
                if (_IsDeletedCity != null)
                {
                    _IsDeletedCity.IsDeleted = true;
                    _IsDeletedCity.IsStatus = false;
                    _IsDeletedCity.IsDeletedAt = DateTime.Now;

                    _aPINegociosDb.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro", ex);
            }
        }
        #endregion

        #region COUNTRIES METODH

        public async Task<Countries> GetByIdCountriesAsync(int Id)
        {
            try
            {
                var getByIdCountries = await _aPINegociosDb.Countries.FirstOrDefaultAsync(x => x.CountryId == Id);
                return getByIdCountries!;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        public async Task<Countries> GetByNameCountrieAsync(string names)
        {
            try
            {
                var getByNameCountry = await _aPINegociosDb.Countries.FirstOrDefaultAsync(x => x.CountryName == names);
                return getByNameCountry!;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }
        public async Task<IEnumerable<Countries>> GetCountries()
        {
            try
            {
                var getConuntry = await _aPINegociosDb.Set<Countries>().OrderBy(e => e.CountryName)
                    .AsNoTracking()
                    .ToListAsync();

                return getConuntry;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }

        }

        public bool GetByCountriesIsDeleted(Countries countries)
        {
            try
            {
                var _getIsDeleted = _aPINegociosDb.Set<Countries>().Find(countries.CountryId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsStatud = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;
                    _getIsDeleted.IsRecurring = false;

                    _aPINegociosDb.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro", ex);
            }
        }

        public async Task<bool> IsUpdated(Countries countries)
        {
            try
            {
                var _countries = await GetByIdCountriesAsync(countries.CountryId) ?? throw new ArgumentNullException("Error...! El ID no fue ingresado.");

                _countries.CountryId = countries.CountryId;
                _countries.StorId = countries.StorId;
                _countries.WhenDate = countries.WhenDate;
                _countries.ProveedorId = countries.ProveedorId;
                _countries.CodeCountries = countries.CodeCountries;
                _countries.CountryName = countries.CountryName;
                _countries.Note = countries.Note;
                _countries.IsDateCreadCountry = countries.IsDateCreadCountry;

                countries.IsUpdated = true;
                countries.IsDeleted = false;
                countries.IsDeletedAt = DateTime.Now;
                countries.IsStatud = true;
                countries.IsDeletedAt = null;
                countries.IsRecurring = true;

                _aPINegociosDb.Entry(_countries).State = EntityState.Modified;
                return await SaveAll();


            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }

        public async Task<bool> IsCread(Countries countries)
        {
            try
            {
                if (countries == null)
                    throw new ArgumentNullException("Por favor, debe completar el formulario.");

                countries.IsStatud = true;
                countries.IsDateCreadCountry = DateTime.Now;
                countries.IsUpdatedAt = null;
                countries.WhenDate = DateTime.Now;
                countries.IsDeletedAt = null;
                countries.IsDeleted = false;
                countries.IsUpdated = false;
                countries.IsRecurring = true;

                _aPINegociosDb.Set<Countries>().Add(countries);
                return await SaveAll();

            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible registrar el nuevo pais.", ex);
            }
        }

        public ICollection<Countries> GetCountriesByCode(string code)
        {
            try
            {
                IQueryable<Countries> query = _aPINegociosDb.Set<Countries>();
                if (!string.IsNullOrEmpty(code))
                    query = query.Where(x => x.CodeCountries.ToLower().Trim() == code.ToLower().Trim());

                return  query.OrderBy(x => x.CountryName).AsNoTracking().ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error...!", ex);
            }
        }


        #endregion

        #region STORES METODH
        public async Task<Stores> GetByIdStoresAsync(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    return await _aPINegociosDb.Stores.FirstOrDefaultAsync(x => x.StorId == Id);
                }
                throw new InvalidOperationException("Error...! No se indico el ID de la tineda.");

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontro ninguna tienda relacionada a ese ID, por favor verificar que el ID sea el correcto.", ex);
            }

        }

        public async Task<Stores> GetByNameStoresAsync(string names)
        {
            try
            {
                if (names != null)
                {

                    return await _aPINegociosDb.Set<Stores>().OrderBy(e => e.StoresName).FirstOrDefaultAsync(x => x.StoresName == names);
                }
                throw new InvalidOperationException("Error...! No se indico el nombre de la tienda.");

            }
            catch (Exception ex)
            {


                throw new Exception("Error! No se encontro ninguna tienda relacionada a ese nombre, por favor verificar que el nombre sea el correcto.", ex);
            }

        }

        public async Task<IEnumerable<Stores>> GetStores()
        {
            try
            {
                return await _aPINegociosDb.Set<Stores>().OrderBy(e => e.StorId)
                   .AsNoTracking()
                   .ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception("Error! No se encontraron ninguna de las tiendas.", ex);
            }

        }

        public bool GetByStoreIsDeleted(Stores stores)
        {
            try
            {
                var _getIsDeleted = _aPINegociosDb.Set<Stores>().Find(stores.StorId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsStatud = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;

                    _aPINegociosDb.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro", ex);
            }
        }

        public bool IsExisteStoresById(int storesId)
        {
            try
            {
                return _aPINegociosDb.Set<Stores>().Any(e => e.StorId == storesId);
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible validar si la tienda existe.", ex);
            }
        }

        public bool IsExisteStoresByName(string name)
        {
            try
            {
                bool existe = _aPINegociosDb.Set<Stores>().Any(e => e.StoresName.ToLower().Trim() == name.ToLower().Trim());
                return existe;
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! No fue posible validar si la tienda existe.", ex);
            }
        }

        public bool IsCread(Stores stores)
        {
            try
            {
                if (stores != null)
                {
                    stores.IsCreadDateStore = DateTime.Now;
                    stores.IsDeleted = false;
                    stores.IsDeletedAt = null;
                    stores.IsModified = null;
                    stores.IsModifiedBy = false;
                    stores.IsStatud = true;

                    _aPINegociosDb.Stores.Add(stores);
                    return LoadAll();
                }
                throw new InvalidOperationException("Error.....!");
            }
            catch (Exception ex)
            {

                throw new Exception("Error...! Algo salió mal al guardar el registro.", ex);
            }
        }

        public bool IsUpdated(Stores stores)
        {
            try
            {
                var _update = GetByIdStoresAsync(stores.StorId).Result ?? throw new ArgumentNullException("Por favor indicar el ID del registro que desea Editar");

                _update.StorId = stores.StorId;
                _update.StoresName = stores.StoresName;
                _update.StoresDescription = stores.StoresDescription;
                _update.StoresTotal = stores.StoresTotal;
                _update.Biography = stores.Biography;
                _update.WebSite = stores.WebSite;
                _update.FacebookAccount = stores.FacebookAccount;
                _update.InstagramAccount = stores.InstagramAccount;
                _update.Address = stores.Address;
                _update.AceptPyments = stores.AceptPyments;
                _update.Latitud = stores.Latitud;
                _update.Longitud = stores.Longitud;
                _update.WhatsAppNumber = stores.WhatsAppNumber;
                _update.PhoneNumber = stores.PhoneNumber;
                _update.OtherNumber = stores.OtherNumber;
                stores.IsDeleted = false;
                _update.IsCreadDateStore = stores.IsCreadDateStore;
                stores.IsModified = DateTime.Now;
                stores.IsDeletedAt = null;
                stores.IsStatud = true;
                _update.CodeStore = stores.CodeStore;
                _update.Stock = stores.Stock;
                _update.IsModifiedBy = true;

                _aPINegociosDb.Entry(_update).State = EntityState.Modified;
                return LoadAll();

            }
            catch (Exception ex)
            {

                throw new Exception("Error....!", ex);
            }
        }




        #endregion
    }
}
