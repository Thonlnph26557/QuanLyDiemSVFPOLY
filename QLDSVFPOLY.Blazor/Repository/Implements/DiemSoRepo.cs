using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class DiemSoRepo : IDiemSoRepo
    {
        HttpClient _httpClient;
        public DiemSoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.TrongSo.ToString()))
                queryString.Add("TrongSo", vm.TrongSo.ToString());
            if (!String.IsNullOrEmpty(vm.TenDauDiem))
                queryString.Add("TenDauDiem", vm.TenDauDiem);
            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());

            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());


            string url = QueryHelpers.AddQueryString("/api/DiemSos/all", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<DiemSoVM>>(url);
            return result;
        }

        public async Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(vm.TrongSo.ToString()))
                queryString.Add("TrongSo", vm.TrongSo.ToString());
            if (!String.IsNullOrEmpty(vm.TenDauDiem))
                queryString.Add("TenDauDiem", vm.TenDauDiem);
            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());

            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());


            string url = QueryHelpers.AddQueryString("/api/DiemSos/all", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<DiemSoVM>>(url);
            return result;
        }

        public async Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<DiemSoVM>($"/api/DiemSos/all?Id={id}");
            return result;
        }

        public async Task<int> CreateAsync(DiemSoCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/DiemSos", vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
        public async Task<int> UpdateAsync(Guid id, DiemSoUpdateVM vm)
        {
            var url = Path.Combine("/api/DiemSos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/DiemSos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
