using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IGiangVienRepo
    {
        Task<List<GiangVienVM>> GetAllAsync();
        Task<List<GiangVienVM>> GetAllActiveAsync();
        Task<GiangVienVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(GiangVienCreateVM obj);
        Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
