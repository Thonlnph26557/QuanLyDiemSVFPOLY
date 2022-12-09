using QLDSVFPOLY.BUS.ViewModels.TaiKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface ITaiKhoanServices
    {
        Task<DangNhapVM> DangNhapAsync(DangNhapVM input);
        Task<bool> UpdateAsync(DoiMatKhauVM vm);
    }
}
