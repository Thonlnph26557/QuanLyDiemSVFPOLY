using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IMonHocRepo
    {
        Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM vm);
        Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM vm);
        Task<MonHocVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(MonHocCreateVM vm);
        Task<bool> UpdateAsync(Guid id, MonHocUpdateVM vm);
        Task<bool> RemoveAsync(Guid id);
    }
}
