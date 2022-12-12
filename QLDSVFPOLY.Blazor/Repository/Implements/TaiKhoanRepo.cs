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

        public async Task<DangNhapResponseVM> LoginAsync(DangNhapVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.TaiKhoan))
                queryString.Add("TaiKhoan", vm.TaiKhoan);
            if (!String.IsNullOrEmpty(vm.MatKhau))
                queryString.Add("MatKhau", vm.MatKhau);
            if (!String.IsNullOrEmpty(vm.ChucVu))
                queryString.Add("ChucVu", vm.ChucVu);

            string url = QueryHelpers.AddQueryString("/api/TaiKhoans", queryString);

            var result = await _httpClient.GetFromJsonAsync<DangNhapResponseVM>(url);
            if (result != null) return result;
            return null;
        }

        public async Task<bool> UpdateAsync(DoiMatKhauVM vm)
        {
            var result = await _httpClient.PutAsJsonAsync("api/TaiKhoans", vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
