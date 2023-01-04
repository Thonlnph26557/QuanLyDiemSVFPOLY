using QLDSVFPOLY.BUS.ViewModels.DiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IDiemSoRepo
    {
        Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj);
        Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj);
        Task<DiemSoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DiemSoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
