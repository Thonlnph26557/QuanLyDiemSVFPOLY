using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChiTietLopHocRepos
    {
        Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj);
        Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj);
        Task<ChiTietLopHocVM> GetByIdAsync(Guid id);
        Task<int> CreateAsync(ChiTietLopHocCreateVM obj);
        Task<int> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj);
        Task<int> RemoveAsync(Guid id);
    }
}
