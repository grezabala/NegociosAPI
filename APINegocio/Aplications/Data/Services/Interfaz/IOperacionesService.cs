using APINegocio.Aplications.Dtos;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface IOperacionesService
    {
        OperacionesPOSTDto IsCread(OperacionesPOSTDto pOSTDto);
        bool IsDeleted(OperacionesDto operacionesDto);
        OperacionesPUTDto IsUpdated(OperacionesPUTDto pUTDto);
        ICollection<OperacionesDto>GetOperacionesDtos();
        OperacionesDto GetOperacionesDtoById(int Id);
    }
}
