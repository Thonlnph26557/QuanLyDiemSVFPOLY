using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChuyenNganhMonHocRepos
    {
        Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM searchVM);

        Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM searchVM);

        Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc);

        Task<int> CreateAsync(ChuyenNganhMonHocCreateVM obj);

        Task<int> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc);
    }
}
