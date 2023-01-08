using QLDSVFPOLY.BUS.ViewModels.ChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChucVuServices
    {
        Task<List<ChucVuVM>> GetAllAsync();
        Task<List<ChucVuVM>> GetAllActiveAsync();
        Task<ChucVuVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(ChucVuCreateVM obj);
        Task<bool> UpdateAsync(Guid id, ChucVuUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
