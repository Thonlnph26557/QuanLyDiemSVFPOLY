using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChuyenNganhMonHocRepo
    {
        Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM obj);
        Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM obj);
        Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc);
        Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj, Guid idChuyenNganh, Guid idMonHoc);
        Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc);
        Task<bool> UpdateTrangThaiAsync(Guid idChuyenNganh, Guid idMonHoc);
    }
}
