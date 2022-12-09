using QLDSVFPOLY.BUS.ViewModels.DiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IDiemSoRepos
    {
        Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM vm);
        Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM vm);
        Task<DiemSoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DiemSoCreateVM vm);
        Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM vm);
        Task<bool> RemoveAsync(Guid id);
    }
}
