using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChuyenNganhRepo
    {
        Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM vm);
        Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM vm);
        Task<ChuyenNganhVM> GetByIdAsync(Guid id);
        Task<int> CreateAsync(ChuyenNganhCreateVM vm);
        Task<int> UpdateAsync(Guid id, ChuyenNganhUpdateVM vm);
        Task<int> RemoveAsync(Guid id);
    }
}
