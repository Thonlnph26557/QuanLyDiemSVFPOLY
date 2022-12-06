using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IGiangVienRepos
    {
        Task<List<GiangVienVM>> GetAllAsync(GiangVienVM searchVM);

        Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienVM searchVM);

        Task<GiangVienVM> GetByIdAsync(Guid id);

        Task<int> CreateAsync(GiangVienVM obj);

        Task<int> UpdateAsync(Guid id, GiangVienVM obj);

        Task<int> RemoveAsync(Guid id);
    }
}
