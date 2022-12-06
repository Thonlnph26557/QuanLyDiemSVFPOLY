using QLDSVFPOLY.BUS.ViewModels.LopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface ILopHocRepos
    {
        Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVM);

        Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVM);

        Task<LopHocVM> GetByIdAsync(Guid id);

        Task<int> CreateAsync(LopHocCreateVM obj);

        Task<int> UpdateAsync(Guid id, LopHocUpdateVM obj);

        Task<int> RemoveAsync(Guid id);
    }
}
