using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NguoiDungChucVu;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class NguoiDungChucVuRepo : INguoiDungChucVuRepo
    {
        HttpClient _httpClient;

        public NguoiDungChucVuRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateAsync(NguoiDungChucVuCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/NguoiDungChucVus", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<NguoiDungChucVuVM>> GetAllActiveAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<NguoiDungChucVuVM>>("/api/NguoiDungChucVus/GetAllActiveAsync");
            return result;
        }

        public async Task<List<NguoiDungChucVuVM>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<NguoiDungChucVuVM>>("/api/NguoiDungChucVus/GetAllAsync");
            return result;
        }

        public async Task<NguoiDungChucVuVM> GetByIdAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var result = await _httpClient.GetFromJsonAsync<NguoiDungChucVuVM>($"/api/NguoiDungChucVus/{idNguoiDung},{idChucVu}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var url = Path.Combine("/api/NguoiDungChucVus", idNguoiDung.ToString(),idChucVu.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var url = Path.Combine("/api/SinhViens", idNguoiDung.ToString(),idChucVu.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, idNguoiDung);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
