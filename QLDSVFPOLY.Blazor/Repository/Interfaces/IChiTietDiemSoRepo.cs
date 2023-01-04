using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IChiTietDiemSoRepo
    {
        Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj);
        Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj);
        Task<ChiTietDiemSoVM> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj);
        Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
    }
}
