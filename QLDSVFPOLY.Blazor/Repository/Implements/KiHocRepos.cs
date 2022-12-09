using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class KiHocRepos : IKiHocRepos
    {
        HttpClient _httpClient;
        public KiHocRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> CreateAsync(KiHocCreateViewmodel obj)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/KiHocs", obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(obj.Ten))
                queryStringParam.Add("Ten", obj.Ten);
            //....
            string url = QueryHelpers.AddQueryString("/api/KiHocs/allActive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<KiHocViewmodel>>(url);
            return result;
        }

        public async Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(obj.Ten))
                queryStringParam.Add("Ten", obj.Ten);
            if (!String.IsNullOrEmpty(obj.TrangThai.ToString()))
                queryStringParam.Add("TrangThai", obj.TrangThai.ToString());
            //....
            string url = QueryHelpers.AddQueryString("/api/KiHocs/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<KiHocViewmodel>>(url);
            return result;
        }

        public async Task<KiHocViewmodel> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<KiHocViewmodel>($"/api/KiHocs/{id}");
            return result;
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/KiHocs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<int> UpdateAsync(Guid id, KiHocUpdateViewmodel obj)
        {
            var url = Path.Combine("/api/KiHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

    }
}
