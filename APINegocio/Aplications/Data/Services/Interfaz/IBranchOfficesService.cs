using APINegocio.Aplications.Dtos;
using APINegocio.Aplications.Entities;

namespace APINegocio.Aplications.Data.Services.Interfaz
{
    public interface IBranchOfficesService
    {
        bool IsCread(BranchOffices creadBranchs);
        bool IsUpdated(BranchOffices updatedBranchs);
        ICollection<BranchOffices> GetBranchOffices();
        BranchOffices GetByBranchOfficeId(int Id);
        ICollection<BranchOffices> GetByBranchOfficeName(string name);
        ICollection<BranchOffices> GetByBranchOfficeCode(string code);
        ICollection<BranchOffices> GetByBranchOfficeIsDeleted(/*string branchDeleted*/);
        bool IsDeleted(BranchOffices branchs);
        bool IsExisteByBranchOfficesName(string name);
        bool IsExisteByBranchOfficesId(int branchId);
        bool IsExisteByBranchOfficesCode(string cod);
        bool IsSaveAll();
    }
}
