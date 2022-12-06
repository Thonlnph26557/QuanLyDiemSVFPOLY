using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChuyenNganhRepo : IChuyenNganhRepo
    {
        HttpClient _httpClient;
        public ChuyenNganhRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.Ma))
                queryString.Add("Ma", vm.Ma);
            if (!String.IsNullOrEmpty(vm.TenNganhHoc))
                queryString.Add("TenNganhHoc", vm.TenNganhHoc);
            if (vm.IdChuyenNganh.HasValue)
                queryString.Add("IdChuyenNganh", vm.IdChuyenNganh.ToString());
            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());


            string url = QueryHelpers.AddQueryString("/api/ChuyenNganhs/all", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhVM>>(url);
            return result;
        }

        public async Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.Ma))
                queryString.Add("Ma", vm.Ma);
            if (!String.IsNullOrEmpty(vm.TenNganhHoc))
                queryString.Add("TenNganhHoc", vm.TenNganhHoc);
            if (vm.IdChuyenNganh.HasValue)
                queryString.Add("IdChuyenNganh", vm.IdChuyenNganh.ToString());
            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());

            string url = QueryHelpers.AddQueryString("/api/ChuyenNganhs/allactive", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhVM>>(url);
            return result;
        }

        public async Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ChuyenNganhVM>($"/api/ChuyenNganhs/all?Id={id}");
            return result;
        }

        public async Task<int> CreateAsync(ChuyenNganhCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChuyenNganhs", vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
        public async Task<int> UpdateAsync(Guid id, ChuyenNganhUpdateVM vm)
        {
            var url = Path.Combine("/api/ChuyenNganhs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/ChuyenNganhs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
