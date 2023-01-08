using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using System.Net.Http.Json;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChuyenNganhRepo : IChuyenNganhRepo
    {
        HttpClient _httpClient;

        public ChuyenNganhRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(ChuyenNganhCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChuyenNganhs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<ChuyenNganhVM>> GetAllActiveAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhVM>>("/api/ChuyenNganhs/GetAllActiveAsync");
            return result;
        }

        public async Task<List<ChuyenNganhVM>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhVM>>("/api/ChuyenNganhs/GetAllAsync");
            return result;
        }

        public async Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ChuyenNganhVM>($"/api/ChuyenNganhs/{id}");
            return result;
        }

        public async Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhVM>>($"/api/ChuyenNganhs/GetChuyenNganhHepById/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/ChuyenNganhs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj)
        {
            var url = Path.Combine("/api/ChuyenNganhs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
