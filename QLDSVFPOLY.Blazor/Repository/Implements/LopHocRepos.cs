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

        public async Task<int> CreateAsync(LopHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/LopHoc", obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<List<LopHocVM>> GetAllAsync(LopHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(searchVM.Ma))
                queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/LopHoc/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<LopHocVM>>(url);
            return result;
        }

        public async Task<List<LopHocVM>> GetAllActiveAsync(LopHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(searchVM.Ma))
                queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/LopHoc/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<LopHocVM>>(url);
            return result;
        }

        public async Task<LopHocVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<LopHocVM>($"/api/LopHoc/all/{id}");
            return result;
        }

        public async Task<int> UpdateAsync(Guid id, LopHocUpdateVM obj)
        {
            var url = Path.Combine("/api/LopHoc", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/LopHoc", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
