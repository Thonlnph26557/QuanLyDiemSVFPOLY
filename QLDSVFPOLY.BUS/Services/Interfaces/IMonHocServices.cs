using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IMonHocServices
    {
        Task<List<MonHocVM>> GetAllAsync();
        Task<List<MonHocVM>> GetAllActiveAsync();
        Task<MonHocVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(MonHocCreateVM obj);
        Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj);
        Task<bool> UpdateRemoveAsync(Guid id);
        Task<bool> RemoveAsync(Guid id);
    }
}
