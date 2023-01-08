using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;
using System;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChuyenNganhMonHocRepo : IChuyenNganhMonHocRepo
    {
        public HttpClient _httpClient { get; set; }

        public ChuyenNganhMonHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM obj)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhMonHocVM>>("/api/ChuyenNganhMonHocs/GetAllAsync");
            return result;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM obj)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhMonHocVM>>("/api/ChuyenNganhMonHocs/GetAllActiveAsync");
            return result;
        }

        public async Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var result = await _httpClient.GetFromJsonAsync<ChuyenNganhMonHocVM>($"/api/ChuyenNganhMonHocs/all/{idChuyenNganh},{idMonHoc}");
            return result;
        }

        public async Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj, Guid idChuyenNganh, Guid idMonHoc)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChuyenNganhMonHocs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var url = Path.Combine("/api/ChuyenNganhMonHocs", idChuyenNganh.ToString(), idMonHoc.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
