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

        public async Task<bool> CreateAsync(GiangVienCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/GiangViens", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(searchVM.Ma))
                queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/GiangViens/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<GiangVienVM>>(url);
            return result;
        }

        public async Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(searchVM.Ma))
                queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/GiangViens/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<GiangVienVM>>(url);
            return result;
        }

        public async Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<GiangVienVM>($"/api/GiangViens/all/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/GiangViens", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM obj)
        {
            var url = Path.Combine("/api/GiangViens", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
