using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface ILopHocServices
    {

        Task<List<LopHocViewmodel>> GetAllAsync(LopHocSearchViewmodel obj);
        Task<List<LopHocViewmodel>> GetAllActiveAsync(LopHocSearchViewmodel obj);
        Task<LopHocViewmodel> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(LopHocCreateViewmodel obj);
        Task<bool> UpdateAsync(Guid id, LopHocUpdateViewmodel obj);
        Task<bool> RemoveAsync(Guid id);

    }
}
