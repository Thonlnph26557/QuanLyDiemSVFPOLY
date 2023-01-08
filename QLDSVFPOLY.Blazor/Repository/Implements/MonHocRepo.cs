using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class MonHocRepo : IMonHocRepo
    {
        HttpClient _httpClient;
        public MonHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj)
        {
            var result = await _httpClient.GetFromJsonAsync<List<MonHocVM>>("/api/Monhocs/GetAllAsync");
            return result;
        }

        public async Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj)
        {
            var result = await _httpClient.GetFromJsonAsync<List<MonHocVM>>("/api/Monhocs/GetAllActiveAsync");
            return result;
        }

        public async Task<MonHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<MonHocVM>($"/api/MonHocs/{id}");
            return result;
        }

        public async Task<bool> CreateAsync(MonHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/MonHocs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj)
        {
            var url = Path.Combine("/api/MonHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/MonHocs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

    }
}
