using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface ISinhVienRepos
    {

        Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM obj);
        Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM obj);
        Task<SinhVienVM> GetByIdAsync(Guid id);

        Task<int> CreateAsync(SinhVienCreateVM obj);
        Task<int> UpdateAsync(Guid id, SinhVienUpdateVM obj);
        Task<int> RemoveAsync(Guid id);
    }
}
