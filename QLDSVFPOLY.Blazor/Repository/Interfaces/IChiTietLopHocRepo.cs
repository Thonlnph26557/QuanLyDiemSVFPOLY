using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChiTietLopHocRepo
    {
        Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj);
        Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj);
        Task<ChiTietLopHocVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(ChiTietLopHocCreateVM obj);
        Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
