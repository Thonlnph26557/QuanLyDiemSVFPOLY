using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.TaiKhoan;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class TaiKhoanRepo : ITaiKhoanRepo
    {
        public HttpClient _httpClient { get; set; }

        public TaiKhoanRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<DangNhapVM> DangNhapAsync(DangNhapVM input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(DoiMatKhauVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
