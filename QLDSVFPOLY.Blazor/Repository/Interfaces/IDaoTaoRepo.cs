using QLDSVFPOLY.BUS.ViewModels.DaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IDaoTaoRepo
    {
        Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj);
        Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj);
        Task<DaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj);
        Task<bool> UpdateRemoveAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
    }
}
