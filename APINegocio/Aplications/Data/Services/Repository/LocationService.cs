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

        private readonly APINegociosDbContext _APINegociosDb;

        public LocationService(APINegociosDbContext aPINegocioDbContext) => _APINegociosDb = aPINegocioDbContext;

        public void Add<TEntitie>(TEntitie entitie) where TEntitie : class
        {
            _APINegociosDb.Add(entitie);
        }

        public void Remove<TEntitie>(TEntitie entitie) where TEntitie : class
        {
            _APINegociosDb.Remove(entitie);
        }

        public async Task<bool> SaveAll()
        {
            return await _APINegociosDb.SaveChangesAsync() > 0;
        }

        public bool LoadAll()
        {
            try
            {
                return _APINegociosDb.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fué posible cargar el registro eliminado", ex);

            }
        }


        #region CITY METODH
        public async Task<City> GetByCodeCityAsync(string code)
        {
            var getByCodeCity = await _APINegociosDb.City.FirstOrDefaultAsync(x => x.Code == code);
            return getByCodeCity!;
        }

        public async Task<City> GetByIdCityAsync(int Id)
        {

            var getByIdCity = await _APINegociosDb.City.FirstOrDefaultAsync(x => x.CityId == Id);
            return getByIdCity!;
        }

        public async Task<City> GetByNameCityAsync(string names)
        {
            var getByNameCity = await _APINegociosDb.City.FirstOrDefaultAsync(x => x.CityName == names);
            return getByNameCity!;
        }

        public async Task<IEnumerable<City>> GetCitys()
        {
            var getCity = await _APINegociosDb.City.ToListAsync();
            return getCity;
        }

        public bool GetByCityIsDeleted(City city)
        {
            try
            {
                var _IsDeletedCity = _APINegociosDb.Set<City>().Find(city.CityId);
                if (_IsDeletedCity != null)
                {
                    _IsDeletedCity.IsDeleted = true;
                    _IsDeletedCity.IsStatus = false;
                    _IsDeletedCity.IsDeletedAt = DateTime.Now;
                    _APINegociosDb.SaveChanges();

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
            var getByIdCountries = await _APINegociosDb.Countries.FirstOrDefaultAsync(x => x.CountryId == Id);
            return getByIdCountries!;
        }

        public async Task<Countries> GetByNameCountrieAsync(string names)
        {
            var getByNameCountry = await _APINegociosDb.Countries.FirstOrDefaultAsync(x => x.CountryName == names);
            return getByNameCountry!;
        }
        public async Task<IEnumerable<Countries>> GetCountries()
        {
            var getConuntry = await _APINegociosDb.Countries.ToListAsync();
            return getConuntry;
        }

        public bool GetByCountriesIsDeleted(Countries countries)
        {
            try
            {
                var _getIsDeleted = _APINegociosDb.Set<Countries>().Find(countries.CountryId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsStatud = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;
                    _APINegociosDb.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro", ex);
            }
        }

        #endregion

        #region STORES METODH
        public async Task<Stores> GetByIdStoresAsync(int Id)
        {
            var getByIdStors = await _APINegociosDb.Stores.FirstOrDefaultAsync(x => x.StorId == Id);
            return getByIdStors!;
        }

        public async Task<Stores> GetByNameStoresAsync(string names)
        {
            var getByNameStors = await _APINegociosDb.Stores.FirstOrDefaultAsync(x => x.StoresName == names);
            return getByNameStors!;
        }

        public async Task<IEnumerable<Stores>> GetStores()
        {
            var getStores = await _APINegociosDb.Stores.ToListAsync();
            return getStores;
        }

        public bool GetByStoreIsDeleted(Stores stores)
        {
            try
            {
                var _getIsDeleted = _APINegociosDb.Set<Stores>().Find(stores.StorId);
                if (_getIsDeleted != null)
                {
                    _getIsDeleted.IsDeleted = true;
                    _getIsDeleted.IsStatud = false;
                    _getIsDeleted.IsDeletedAt = DateTime.Now;
                    _APINegociosDb.SaveChanges();

                }

                return LoadAll();
            }
            catch (Exception ex)
            {

                throw new Exception("Error! No fue posible eliminar el registro", ex);
            }
        }
        #endregion
    }
}
