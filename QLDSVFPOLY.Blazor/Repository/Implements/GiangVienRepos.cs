using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class GiangVienRepos : IGiangVienRepos
    {
        public HttpClient _httpClient { get; set; }

        public GiangVienRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateAsync(GiangVienVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/GiangVien", obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(searchVM.Ma))
                queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/GiangVien/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<GiangVienVM>>(url);
            return result;
        }

        public async Task<List<GiangVienVM>> GetAllAsync(GiangVienVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(searchVM.Ma))
                queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/GiangVien/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<GiangVienVM>>(url);
            return result;
        }

        public async Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<GiangVienVM>($"/api/GiangVien/all/{id}");
            return result;
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/GiangVien", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<int> UpdateAsync(Guid id, GiangVienVM obj)
        {
            var url = Path.Combine("/api/GiangVien", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
