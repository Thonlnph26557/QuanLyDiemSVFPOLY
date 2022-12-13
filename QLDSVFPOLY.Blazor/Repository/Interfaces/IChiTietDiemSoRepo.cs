using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChiTietDiemSoRepo
    {
        Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM vm);
        Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM vm);
        Task<ChiTietDiemSoVM> GetByIdAsync(Guid idLopHoc, Guid idDiemSo, Guid idSinhVien);
        Task<bool> CreateAsync(ChiTietDiemSoCreateVM vm);
        Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
