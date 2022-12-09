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
        public async Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/NhanVienDaoTaos", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(obj.Ma))
                queryStringParam.Add("Ma", obj.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/NhanVienDaoTaos/allactive", queryStringParam);
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
            string url = QueryHelpers.AddQueryString("/api/NhanVienDaoTaos/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<NhanVienDaoTaoVM>>(url);
            return result;
        }

        public async Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<NhanVienDaoTaoVM>($"/api/NhanVienDaoTaos/{id}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/NhanVienDaoTaos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj)
        {
            var url = Path.Combine("/api/NhanVienDaoTaos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
