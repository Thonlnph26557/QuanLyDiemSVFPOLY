using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class NhanVienDaoTaoRepos : INhanVienDaoTaoRepos
    {
        HttpClient _httpClient;
        public NhanVienDaoTaoRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> CreateAsync(NhanVienDaoTaoCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/NhanVienDaoTao", obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(obj.Ma))
                queryStringParam.Add("Ma", obj.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/NhanVienDaoTao/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<NhanVienDaoTaoVM>>(url);
            return result;
        }

        public async Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(obj.Ma))
                queryStringParam.Add("Ma", obj.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/NhanVienDaoTao/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<NhanVienDaoTaoVM>>(url);
            return result;
        }

        public async Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<NhanVienDaoTaoVM>($"/api/NhanVienDaoTao/all/{id}");
            return result;
        }

        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/NhanVienDaoTao", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<int> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj)
        {
            var url = Path.Combine("/api/NhanVienDaoTao", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
