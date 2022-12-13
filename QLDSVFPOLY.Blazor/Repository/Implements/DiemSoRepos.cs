using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class DiemSoRepos : IDiemSoRepos
    {
        HttpClient _httpClient;
        public DiemSoRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();
            if (!String.IsNullOrEmpty(vm.IdMonHoc.ToString()))
                queryString.Add("IdMonHoc", vm.TrongSo.ToString());
            if (!String.IsNullOrEmpty(vm.TrongSo.ToString()))
                queryString.Add("TrongSo", vm.TrongSo.ToString());
            if (!String.IsNullOrEmpty(vm.TenDauDiem))
                queryString.Add("TenDauDiem", vm.TenDauDiem);
            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());

            string url = QueryHelpers.AddQueryString("/api/DiemSos/all", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<DiemSoVM>>(url);
            return result;
        }

        public async Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            
            ////if (!String.IsNullOrEmpty(vm.TenDauDiem))
            //    queryString.Add("TenDauDiem", vm.TenDauDiem);

            string url = QueryHelpers.AddQueryString("/api/DiemSos/allactive", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<DiemSoVM>>(url);
            return result;
        }

        public async Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<DiemSoVM>($"/api/DiemSos/{id}");
            return result;
        }

        public async Task<bool> CreateAsync(DiemSoCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/DiemSos", vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM vm)
        {
            var url = Path.Combine("/api/DiemSos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/DiemSos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
