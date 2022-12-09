using QLDSVFPOLY.BUS.ViewModels.LopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface ILopHocRepos
    {
        Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVM);

        Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVM);

        Task<LopHocVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(LopHocCreateVM obj);

        Task<bool> UpdateAsync(Guid id, LopHocUpdateVM obj);

        Task<bool> RemoveAsync(Guid id);
    }
}
