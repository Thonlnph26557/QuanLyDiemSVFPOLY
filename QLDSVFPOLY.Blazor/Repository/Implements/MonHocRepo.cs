using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class MonHocRepo : IMonHocRepo
    {
        HttpClient _httpClient;
        public MonHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.Ma))
                queryString.Add("Ma", vm.Ma);
            if (!String.IsNullOrEmpty(vm.Ten))
                queryString.Add("TenNganhHoc", vm.Ten);


            string url = QueryHelpers.AddQueryString("/api/Monhocs/all", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<MonHocVM>>(url);
            return result;
        }

        public async Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.Ma))
                queryString.Add("Ma", vm.Ma);
            if (!String.IsNullOrEmpty(vm.Ten))
                queryString.Add("TenNganhHoc", vm.Ten);


            string url = QueryHelpers.AddQueryString("/api/Monhocs/allactive", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<MonHocVM>>(url);
            return result;
        }

        public async Task<MonHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<MonHocVM>($"/api/MonHocs/all?Id={id}");
            return result;
        }

        public async Task<bool> CreateAsync(MonHocCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/MonHocs", vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> UpdateAsync(Guid id, MonHocUpdateVM vm)
        {
            var url = Path.Combine("/api/MonHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
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
