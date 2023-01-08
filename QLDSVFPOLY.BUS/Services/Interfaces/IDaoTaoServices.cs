using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IDaoTaoServices
    {
        Task<List<DaoTaoVM>> GetAllAsync();
        Task<List<DaoTaoVM>> GetAllActiveAsync();
        Task<DaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj);
        Task<bool> UpdateRemoveAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
    }
}
