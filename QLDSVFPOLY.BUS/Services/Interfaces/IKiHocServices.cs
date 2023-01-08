using QLDSVFPOLY.BUS.ViewModels.KiHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IKiHocServices
    {

        Task<List<KiHocVM>> GetAllAsync();
        Task<List<KiHocVM>> GetAllActiveAsync();
        Task<KiHocVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(KiHocCreateVM obj);
        Task<bool> UpdateAsync(Guid id, KiHocUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
