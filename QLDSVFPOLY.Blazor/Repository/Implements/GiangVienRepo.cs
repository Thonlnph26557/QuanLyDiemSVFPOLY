using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class GiangVienRepo : IGiangVienRepo
    {
        HttpClient _httpClient;

        public GiangVienRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GiangVienVM>> GetAllAsync()
        {
            var queryStringParam = new Dictionary<string, string>();
            string url = QueryHelpers.AddQueryString("/api/GiangViens/GetAllAsync", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<GiangVienVM>>(url);
            return result;
        }

        public async Task<List<GiangVienVM>> GetAllActiveAsync()
        {
            var queryStringParam = new Dictionary<string, string>();
            string url = QueryHelpers.AddQueryString("/api/GiangViens/GetAllActiveAsync", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<GiangVienVM>>(url);
            return result;
        }

        public async Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<GiangVienVM>($"/api/GiangViens/{id}");
            return result;
        }

        public async Task<bool> CreateAsync(GiangVienCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/GiangViens", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM obj)
        {
            var url = Path.Combine("/api/GiangViens", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/GiangViens", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
