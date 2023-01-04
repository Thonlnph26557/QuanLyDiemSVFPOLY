using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChuyenNganhRepo
    {
        Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM obj);
        Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj);
        Task<ChuyenNganhVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ChuyenNganhCreateVM obj);
        Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateTrangThaiAsync(Guid id);
        Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id);
    }
}
