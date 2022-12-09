using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface INhanVienDaoTaoRepos
    {
        Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj);
        Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj);
        Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
