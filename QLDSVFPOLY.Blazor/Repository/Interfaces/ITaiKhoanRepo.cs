using QLDSVFPOLY.BUS.ViewModels.TaiKhoan;

namespace QLDSVFPOLY.Blazor.Repository.Interfaces
{
    public interface ITaiKhoanRepo
    {
        Task<DangNhapResponseVM> LoginAsync(DangNhapVM vm);
        Task<bool> UpdateAsync(DoiMatKhauVM vm);
    }
}
