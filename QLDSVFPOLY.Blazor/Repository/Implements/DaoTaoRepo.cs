using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class DaoTaoRepo : IDaoTaoRepo
    {
        //
        HttpClient _httpClient;

        //
        public DaoTaoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(DaoTaoCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/DaoTaos", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<DaoTaoVM>> GetAllActiveAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DaoTaoVM>>("/api/DaoTaos/GetAllActiveAsync");
            return result;
        }

        public async Task<List<DaoTaoVM>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DaoTaoVM>>("/api/DaoTaos/GetAllAsync");
            return result;
        }

        public async Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<DaoTaoVM>($"/api/DaoTaos/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/DaoTaos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj)
        {
           var url = Path.Combine("/api/DaoTaos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

    }
}
