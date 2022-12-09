using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IKiHocRepos
    {
        Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj);
        Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj);
        Task<KiHocViewmodel> GetByIdAsync(Guid id);
        Task<int> CreateAsync(KiHocCreateViewmodel obj);
        Task<int> UpdateAsync(Guid id, KiHocUpdateViewmodel obj);
        Task<int> RemoveAsync(Guid id);
    }
}
