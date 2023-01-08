using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IKiHocRepo
    {
        Task<List<KiHocVM>> GetAllAsync();
        Task<List<KiHocVM>> GetAllActiveAsync();
        Task<KiHocVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(KiHocCreateVM obj);
        Task<bool> UpdateAsync(Guid id, KiHocUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
