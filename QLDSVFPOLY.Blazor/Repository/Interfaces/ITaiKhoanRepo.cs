using QLDSVFPOLY.BUS.ViewModels.TaiKhoan;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface ITaiKhoanRepo
    {
        Task<DangNhapVM> DangNhapAsync(DangNhapVM input);
        Task<bool> UpdateAsync(DoiMatKhauVM vm);
    }
}
