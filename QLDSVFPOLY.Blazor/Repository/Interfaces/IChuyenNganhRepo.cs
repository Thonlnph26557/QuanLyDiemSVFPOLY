using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChuyenNganhRepo
    {
        Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM vm);
        Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM vm);
        Task<ChuyenNganhVM> GetByIdAsync(Guid id);
        Task<List<ChuyenNganhVM>> GetChuyenNganhHepByIdAsync(Guid id);
        Task<bool> CreateAsync(ChuyenNganhCreateVM vm);
        Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM vm);
        Task<bool> RemoveAsync(Guid id);
    }
}
