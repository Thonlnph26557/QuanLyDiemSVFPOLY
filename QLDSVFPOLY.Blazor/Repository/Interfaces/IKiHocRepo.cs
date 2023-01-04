using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IKiHocRepo
    {
        Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj);
        Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj);
        Task<KiHocViewmodel> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(KiHocCreateViewmodel obj);
        Task<bool> UpdateAsync(Guid id, KiHocUpdateViewmodel obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
