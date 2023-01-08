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
        Task<List<GiangVienVM>> GetAllAsync();
        Task<List<GiangVienVM>> GetAllActiveAsync();
        Task<GiangVienVM> GetByIdAsync(Guid id);

        Task<bool> CreateAsync(GiangVienCreateVM obj);
        Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);

    }
}
