using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChuyenNganhMonHocServices
    {
        Task<List<ChuyenNganhMonHocVM>> GetAllAsync();
        Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync();
        Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc);
        Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj, Guid idChuyenNganh, Guid idMonHoc);
        Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc);
        Task<bool> UpdateTrangThaiAsync(Guid idChuyenNganh, Guid idMonHoc);
    }
}
