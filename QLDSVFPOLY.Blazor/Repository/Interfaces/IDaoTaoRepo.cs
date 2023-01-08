using QLDSVFPOLY.BUS.ViewModels.DaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IDaoTaoRepo
    {
        Task<List<DaoTaoVM>> GetAllAsync();
        Task<List<DaoTaoVM>> GetAllActiveAsync();
        Task<DaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
