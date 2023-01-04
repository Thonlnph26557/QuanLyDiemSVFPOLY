using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IMonHocRepo
    {
        Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj);
        Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj);
        Task<MonHocVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(MonHocCreateVM obj);
        Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj);
        Task<bool> UpdateRemoveAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
    }
}
