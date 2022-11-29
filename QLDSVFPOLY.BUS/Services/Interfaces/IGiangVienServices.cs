using QLDSVFPOLY.BUS.ViewModels.GiangVien;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IGiangVienServices
    {

        Task<List<GiangVienViewmodel>> GetAllAsync(GiangVienSearchViewmodel obj);
        Task<List<GiangVienViewmodel>> GetAllActiveAsync(GiangVienSearchViewmodel obj);
        Task<GiangVienViewmodel> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(GiangVienCreateViewmodel obj);
        Task<bool> UpdateAsync(Guid id, GiangVienUpdateViewmodel obj);
        Task<bool> RemoveAsync(Guid id);

    }
}
