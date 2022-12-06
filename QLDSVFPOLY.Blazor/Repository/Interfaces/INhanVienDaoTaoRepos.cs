using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface INhanVienDaoTaoRepos
    {
        Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj);
        Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj);
        Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id);
        Task<int> CreateAsync(NhanVienDaoTaoCreateVM obj);
        Task<int> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj);
        Task<int> RemoveAsync(Guid id);
    }
}
