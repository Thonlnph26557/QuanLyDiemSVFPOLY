using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChiTietDiemSoRepo : IChiTietDiemSoRepo
    {
        HttpClient _httpClient;
        public ChiTietDiemSoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (vm.IdChiTietLopHoc.HasValue)
                queryString.Add("IdChiTietLopHoc", vm.IdChiTietLopHoc.ToString());
            if (vm.IdSinhVien.HasValue)
                queryString.Add("IdSinhVien", vm.IdSinhVien.ToString());
            if (vm.IdDiemSo.HasValue)
                queryString.Add("IdDiemSo", vm.IdDiemSo.ToString());
            if (!String.IsNullOrEmpty(vm.TrangThai.ToString()))
                queryString.Add("TrangThai", vm.TrangThai.ToString());


            string url = QueryHelpers.AddQueryString("/api/ChiTietDiemSos/all", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<ChiTietDiemSoVM>>(url);
            return result;
        }

        public async Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM vm)
        {
            var queryString = new Dictionary<string, string>();

            if (vm.IdChiTietLopHoc.HasValue)
                queryString.Add("IdChiTietLopHoc", vm.IdChiTietLopHoc.ToString());
            if (vm.IdSinhVien.HasValue)
                queryString.Add("IdSinhVien", vm.IdSinhVien.ToString());
            if (vm.IdDiemSo.HasValue)
                queryString.Add("IdDiemSo", vm.IdDiemSo.ToString());



            string url = QueryHelpers.AddQueryString("/api/ChiTietDiemSos/allactive", queryString);
            var result = await _httpClient.GetFromJsonAsync<List<ChiTietDiemSoVM>>(url);
            return result;
        }

        public async Task<ChiTietDiemSoVM> GetByIdAsync(Guid idLopHoc, Guid idDiemSo, Guid idSinhVien)
        {
            var result = await _httpClient.GetFromJsonAsync<ChiTietDiemSoVM>($"/api/ChiTietDiemSos?idDS={idDiemSo}&idLH={idLopHoc}&idSV={idSinhVien}");
            return result;
        }

        public async Task<bool> CreateAsync(ChiTietDiemSoCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChiTietDiemSos", vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> UpdateAsync(Guid id, ChiTietDiemSoUpdateVM vm)
        {
            var url = Path.Combine("/api/ChiTietDiemSos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/ChiTietDiemSos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
