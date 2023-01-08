using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class KiHocRepo : IKiHocRepo
    {
        HttpClient _httpClient;
        public KiHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(KiHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/KiHocs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async  Task<List<KiHocVM>> GetAllActiveAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<KiHocVM>>("/api/KiHocs/GetAllActiveAsync");
            return result;
        }

        public async Task<List<KiHocVM>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<KiHocVM>>("/api/KiHocs/GetAllAsync");
            return result;
        }

        public async Task<KiHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<KiHocVM>($"/api/KiHocs/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/KiHocs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, KiHocUpdateVM obj)
        {
            var url = Path.Combine("/api/KiHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
