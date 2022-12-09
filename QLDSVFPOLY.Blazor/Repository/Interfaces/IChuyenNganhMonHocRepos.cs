using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChuyenNganhMonHocRepos
    {
        Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM searchVM);

        Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM searchVM);

        Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc);

        Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj);

        Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc);
    }
}
