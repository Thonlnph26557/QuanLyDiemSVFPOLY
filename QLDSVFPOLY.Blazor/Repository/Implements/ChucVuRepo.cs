using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChucVu;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChucVuRepo : IChucVuRepo
    {
        HttpClient _httpClient;

        public ChucVuRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(ChucVuCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/ChucVus", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<ChucVuVM>> GetAllActiveAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChucVuVM>>("/api/ChucVus/GetAllActiveAsync");
            return result;
        }

        public async Task<List<ChucVuVM>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChucVuVM>>("/api/ChucVus/GetAllAsync");
            return result;
        }

        public async Task<ChucVuVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ChucVuVM>($"/api/ChucVus/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/ChucVus", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, ChucVuUpdateVM obj)
        {
            var url = Path.Combine("/api/ChucVus", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
