using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IGiangVienRepo
    {
        Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVm);
        Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVm);
        Task<GiangVienVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(GiangVienCreateVM createVm);
        Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM updateVm);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateTrangThaiAsync(Guid id);
    }
}
