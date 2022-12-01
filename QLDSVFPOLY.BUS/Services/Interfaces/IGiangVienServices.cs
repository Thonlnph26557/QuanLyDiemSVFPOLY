using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IGiangVienServices
    {
        Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVm);
        Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVm);
        Task<GiangVienVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(GiangVienCreateVM createVm);
        Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM updateVm);
        Task<bool> RemoveAsync(Guid id);

    }
}
