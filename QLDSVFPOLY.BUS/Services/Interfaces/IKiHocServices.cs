using QLDSVFPOLY.BUS.ViewModels.KiHoc;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IKiHocServices
    {

        Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj);
        Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj);
        Task<KiHocViewmodel> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(KiHocCreateViewmodel obj);
        Task<bool> UpdateAsync(Guid id, KiHocUpdateViewmodel obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
