using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface INhanVienDaoTaoServices
    {
        Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj);
        Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj);
        Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj);
        Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj);
        Task<bool> UpdateRemoveAsync(Guid id);

        Task<bool> RemoveAsync(Guid id);
    }
}
