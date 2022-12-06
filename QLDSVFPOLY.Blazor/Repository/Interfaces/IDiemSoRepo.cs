using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IDiemSoRepo
    {
        Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM vm);
        Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM vm);
        Task<DiemSoVM> GetByIdAsync(Guid id);
        Task<int> CreateAsync(DiemSoCreateVM vm);
        Task<int> UpdateAsync(Guid id, DiemSoUpdateVM vm);
        Task<int> RemoveAsync(Guid id);
    }
}
