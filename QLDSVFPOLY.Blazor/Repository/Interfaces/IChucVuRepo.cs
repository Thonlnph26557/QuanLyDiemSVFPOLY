using QLDSVFPOLY.BUS.ViewModels.ChucVu;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChucVuRepo
    {
        Task<List<ChucVuVM>> GetAllAsync();
        Task<List<ChucVuVM>> GetAllActiveAsync();
        Task<ChucVuVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ChucVuCreateVM obj);
        Task<bool> UpdateAsync(Guid id, ChucVuUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
