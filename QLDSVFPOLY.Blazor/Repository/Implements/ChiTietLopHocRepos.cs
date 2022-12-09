using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChiTietLopHocRepos : IChiTietLopHocRepos
    {
        HttpClient _httpClient;
        public ChiTietLopHocRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> CreateAsync(ChiTietLopHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChiTietLopHocs", obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            string url = QueryHelpers.AddQueryString("/api/ChiTietLopHocs/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<ChiTietLopHocVM>>(url);
            return result;
        }

        public async Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            string url = QueryHelpers.AddQueryString("/api/ChiTietLopHocs/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<ChiTietLopHocVM>>(url);
            return result;
        }

        public async Task<ChiTietLopHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ChiTietLopHocVM>($"/api/ChiTietLopHocs/{id}");
            return result;
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/ChiTietLopHocs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<int> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj)
        {
            var url = Path.Combine("/api/ChiTietLopHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
