using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.LopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class LopHocRepos : ILopHocRepos
    {
        public HttpClient _httpClient { get; set; }

        public LopHocRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(LopHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/LopHocs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            ////Add search Mã
            //if (!String.IsNullOrEmpty(searchVM.Ma))
            //    queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/LopHocs/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<LopHocVM>>(url);
            return result;
        }

        public async Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            ////Add search Mã
            //if (!String.IsNullOrEmpty(searchVM.Ma))
            //    queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/LopHocs/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<LopHocVM>>(url);
            return result;
        }

        public async Task<LopHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<LopHocVM>($"/api/LopHocs/{id}");
            return result;
        }

        public async Task<bool> UpdateAsync(Guid id, LopHocUpdateVM obj)
        {
            var url = Path.Combine("/api/LopHocs", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/LopHocs", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
