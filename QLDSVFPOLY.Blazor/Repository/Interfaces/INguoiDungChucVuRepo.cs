using QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface INguoiDungChucVuRepo
    {
        Task<List<NguoiDungChucVuVM>> GetAllAsync();
        Task<List<NguoiDungChucVuVM>> GetAllActiveAsync();
        Task<NguoiDungChucVuVM> GetByIdAsync(Guid idNguoiDung, Guid idChucVu);
        Task<bool> CreateAsync(NguoiDungChucVuCreateVM obj);
        Task<bool> UpdateAsync(Guid idNguoiDung, Guid idChucVu);
        Task<bool> RemoveAsync(Guid idNguoiDung, Guid idChucVu);
    }
}
