using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IGiangVienRepos
    {
        Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVM);

        Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVM);

        Task<GiangVienVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(GiangVienCreateVM obj);

        Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM obj);

        Task<bool> RemoveAsync(Guid id);
    }
}
