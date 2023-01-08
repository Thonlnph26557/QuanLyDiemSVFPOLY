using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class SinhVienRepo : ISinhVienRepo
    {
        //
        HttpClient _httpClient;

        //
        public SinhVienRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(SinhVienCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/SinhViens", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<SinhVienVM>> GetAllActiveAsync()
        {
            var queryStringParam = new Dictionary<string, string>();
            string url = QueryHelpers.AddQueryString("/api/SinhViens/GetAllActiveAsync", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<SinhVienVM>>(url);
            return result;
        }

        public async Task<List<SinhVienVM>> GetAllAsync()
        {
            var queryStringParam = new Dictionary<string, string>();
            string url = QueryHelpers.AddQueryString("/api/SinhViens/GetAllAsync", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<SinhVienVM>>(url);
            return result;
        }

        public async Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<SinhVienVM>($"/api/SinhViens/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/SinhViens", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj)
        {
            var url = Path.Combine("/api/SinhViens", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
