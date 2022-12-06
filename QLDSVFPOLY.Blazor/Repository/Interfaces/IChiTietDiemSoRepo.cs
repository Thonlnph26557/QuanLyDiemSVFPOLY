using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChiTietDiemSoRepo
    {
        Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM vm);
        Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM vm;
        Task<ChiTietDiemSoVM> GetByIdAsync(Guid id);
        Task<int> CreateAsync(ChiTietDiemSoCreateVM vm);
        Task<int> UpdateAsync(Guid id, ChiTietDiemSoUpdateVM vm);
        Task<int> RemoveAsync(Guid id);
    }
}
