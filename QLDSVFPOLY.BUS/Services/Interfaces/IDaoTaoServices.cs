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
        Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj);
        Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj);
        Task<DaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
