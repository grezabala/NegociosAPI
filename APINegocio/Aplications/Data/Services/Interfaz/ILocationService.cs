using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface ILocationService
    {
        void Add<TEntitie>(TEntitie entitie) where TEntitie : class;
        void Remove<TEntitie>(TEntitie entitie) where TEntitie : class;
        Task<bool> SaveAll();
        bool LoadAll();

        //City
        Task<IEnumerable<City>> GetCitys();
        Task<City> GetByIdCityAsync(int Id);
        Task<City> GetByCodeCityAsync(string code);
        Task<City> GetByNameCityAsync(string names);
        bool GetByCityIsDeleted(City city);

        //Countries
        Task<IEnumerable<Countries>> GetCountries();
        Task<Countries> GetByIdCountriesAsync(int Id);
        Task<Countries> GetByNameCountrieAsync(string names);
        bool GetByCountriesIsDeleted(Countries countries);

        //Stores
        Task<IEnumerable<Stores>> GetStores();
        Task<Stores> GetByIdStoresAsync(int Id);
        Task<Stores> GetByNameStoresAsync(string names);
        bool GetByStoreIsDeleted(Stores stores);

        //EVALUAR LA LOGICA SI SE DEBE BUSCAR UNA TIENDA POR SU NOMBRE EN FACEBOOK O INSTAGRAM

    }
}
