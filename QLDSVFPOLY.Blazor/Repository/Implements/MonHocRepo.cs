using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;
using QLDSVFPOLY.DAL.Entities;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class MonHocRepos : IMonHocRepos
    {
        //
        HttpClient _httpClient; 

        //
        public MonHocRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //
        public async Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM vm)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(vm.Ma))
                queryStringParam.Add("Ma", vm.Ma);

            //Add search Ten
            if (!String.IsNullOrEmpty(vm.Ten))
                queryStringParam.Add("Ten", vm.Ten);


            //....
            string url = QueryHelpers.AddQueryString("/api/MonHocs/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<MonHocVM>>(url);
            return result;
        }

        //
        public async Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM vm)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(vm.Ma))
                queryStringParam.Add("Ma", vm.Ma);

            //Add search Ten
            if (!String.IsNullOrEmpty(vm.Ten))
                queryStringParam.Add("Ten", vm.Ten);


            //....
            string url = QueryHelpers.AddQueryString("/api/MonHocs/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<MonHocVM>>(url);
            return result;
        }

        //
        public async Task<MonHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<MonHocVM>($"/api/MonHocs/all/{id}");
            return result;
        }

        //
        public async Task<int> CreateAsync(MonHocCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/MonHocs", vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        //
        public async Task<int> UpdateAsync(Guid id, MonHocUpdateVM vm)
        {
            var url = Path.Combine("/api/MonHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        //
        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/MonHocs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
