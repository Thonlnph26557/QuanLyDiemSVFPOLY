using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface IMonHocRepos
    {

        Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj);
        Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj);
        Task<MonHocVM> GetByIdAsync(Guid id);

        Task<int> CreateAsync(MonHocCreateVM obj);
        Task<int> UpdateAsync(Guid id, MonHocUpdateVM obj);
        Task<int> RemoveAsync(Guid id);

    }
}
