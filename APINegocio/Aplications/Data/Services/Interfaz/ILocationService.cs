using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface ILocationService
    {
        void Add<TEntitie>(TEntitie entitie) where TEntitie : class;
        void Remove<TEntitie>(TEntitie entitie) where TEntitie : class;
        Task<bool> SaveAll();
        //void IsUpdated<TEntitie>(TEntitie entitie) where TEntitie : class;
        bool LoadAll();

        //City
        Task<IEnumerable<City>> GetCitys();
        Task<City> GetByIdCityAsync(int Id);
        Task<City> GetByCodeCityAsync(string code);
        Task<ICollection<City>> GetByNameCityAsync(string names);
        bool GetByCityIsDeleted(City city);
        Task<bool> IsCread(City city);
        Task<bool> IsUpdated(City city);

        //Countries
        Task<IEnumerable<Countries>> GetCountries();
        Task<Countries> GetByIdCountriesAsync(int Id);
        Task<Countries> GetByNameCountrieAsync(string names);
        bool GetByCountriesIsDeleted(Countries countries);
        Task<bool> IsUpdated(Countries countries);
        Task<bool> IsCread(Countries countries);
        ICollection<Countries> GetCountriesByCode(string code);

        //Stores
        Task<IEnumerable<Stores>> GetStores();
        Task<Stores> GetByIdStoresAsync(int Id);
        Task<ICollection<Stores>> GetByNameStoresAsync(string names);
        bool GetByStoreIsDeleted(Stores stores);
        bool IsExisteStoresById(int storesId);
        bool IsExisteStoresByName(string name);
        bool IsCread(Stores stores);
        bool IsUpdated(Stores stores);

        //EVALUAR LA LOGICA SI SE DEBE BUSCAR UNA TIENDA POR SU NOMBRE EN FACEBOOK O INSTAGRAM

    }
}
