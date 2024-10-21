using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface IOperacionesService
    {
        Operaciones IsCread(Operaciones cread);
        bool IsDeleted(Operaciones operaciones);
        Operaciones IsUpdated(Operaciones updated);
        ICollection<Operaciones>GetOperacionesDtos();
        Operaciones GetOperacionesDtoById(int Id);
        ICollection<Operaciones> GetOperacionesByTipo(string tipo);
    }
}
