using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface IBranchOfficesService
    {
        bool IsCread(BranchOffices creadBranchs);
        bool IsUpdated(BranchOffices updatedBranchs);
        ICollection<BranchOffices> List();
        BranchOffices ListById(int Id);
        ICollection<BranchOffices> ListByName(string name);
        ICollection<BranchOffices> ListByCode(string code);
        bool IsDeleted(BranchOffices branchs);
        bool IsExisteByBranchOfficesName(string name);
        bool IsExisteByBranchOfficesId(int branchId);
        bool IsExisteByBranchOfficesCode(string cod);
        bool IsSaveAll();
    }
}
