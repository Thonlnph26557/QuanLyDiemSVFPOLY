using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NguoiDung;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class NguoiDungRepo : INguoiDungRepo
    {
        HttpClient _httpClient;

        //
        public NguoiDungRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(NguoiDungCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/NguoiDungs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<NguoiDungVM>> GetAllActiveAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<NguoiDungVM>>("/api/NguoiDungs/GetAllActiveAsync");
            return result;
        }

        public async Task<List<NguoiDungVM>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<NguoiDungVM>>("/api/NguoiDungs/GetAllAsync");
            return result;
        }

        public async Task<NguoiDungVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<NguoiDungVM>($"/api/NguoiDungs/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/NguoiDungs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, NguoiDungUpdateVM obj)
        {
            var url = Path.Combine("/api/NguoiDungs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
