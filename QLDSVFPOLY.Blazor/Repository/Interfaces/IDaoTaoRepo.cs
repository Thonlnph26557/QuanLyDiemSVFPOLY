using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IDaoTaoRepos
    {
        Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj);
        Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj);
        Task<DaoTaoVM> GetByIdAsync(Guid id);

        Task<int> CreateAsync(DaoTaoCreateVM obj);
        Task<int> UpdateAsync(Guid id, DaoTaoUpdateVM obj);
        Task<int> RemoveAsync(Guid id);

    }
}
