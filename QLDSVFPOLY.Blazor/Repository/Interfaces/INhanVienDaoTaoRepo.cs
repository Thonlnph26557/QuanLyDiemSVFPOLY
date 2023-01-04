using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface INhanVienDaoTaoRepo
    {
        Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj);
        Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj);
        Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj);
        Task<bool> UpdateRemoveAsync(Guid id);

        Task<bool> RemoveAsync(Guid id);
    }
}
