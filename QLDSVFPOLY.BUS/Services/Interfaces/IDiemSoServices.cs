using QLDSVFPOLY.BUS.ViewModels.DiemSo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IDiemSoServices
    {
        Task<List<DiemSoVM>> GetAllAsync();
        Task<List<DiemSoVM>> GetAllActiveAsync();
        Task<DiemSoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(DiemSoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> RemoveByUpdateAsync(Guid id);
    }
}
