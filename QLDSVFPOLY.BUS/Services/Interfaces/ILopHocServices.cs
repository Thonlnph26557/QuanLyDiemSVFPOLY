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

        Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVm);
        Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVm);
        Task<LopHocVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(LopHocCreateVM createVm);
        Task<bool> UpdateAsync(Guid id, LopHocUpdateVM updateVm);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateTrangThaiAsync(Guid id);
    }
}
