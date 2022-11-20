using QLDSVFPOLY.BUS.ViewModels.SinhVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface ISinhVienServices
    {
        Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM obj);
        Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM obj);
        Task<SinhVienVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(SinhVienCreateVM obj);
        Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj);
        Task<bool> RemoveAsync(Guid id);
    }
}
