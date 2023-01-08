using QLDSVFPOLY.BUS.ViewModels.NguoiDung;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface INguoiDungRepo
    {
        Task<List<NguoiDungVM>> GetAllAsync();
        Task<List<NguoiDungVM>> GetAllActiveAsync();
        Task<NguoiDungVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(NguoiDungCreateVM obj);
        Task<bool> UpdateAsync(Guid id, NguoiDungUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
