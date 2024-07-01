using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface ITickersService
    {
        //Tickers
        Task<IEnumerable<Tickers>> GetTickers();
        Tickers GetTickersById(int Id);
        Task<ICollection<Tickers>> GetTickersByNameAsync(string names);
        Task<ICollection<Tickers>> GetTickersByCodeAsync(string code);
        Task<ICollection<Tickers>> GetByTickersDateAsync(DateTime date);
        Task<ICollection<Tickers>> GetByTickersNIFAsync(int TickerNIF);
        Task<ICollection<Tickers>> GetByTickersRNCAsync(int TickerRNC);
        bool GetByTickersIsDeleted(Tickers senders);
        bool IsCreadAsync(Tickers tickers);
        bool IsUpdated(Tickers tickers);
        bool IsExisteByTickersId(int Id);
        bool IsExisteByTickersName(string Name);
        bool IsExisteByTickersCode(string Code);
        bool IsExisteByTickersRNC(int RNC);
        bool IsExisteByTickersNIF(int NIF);
        bool IsSaveAll();
    }
}
