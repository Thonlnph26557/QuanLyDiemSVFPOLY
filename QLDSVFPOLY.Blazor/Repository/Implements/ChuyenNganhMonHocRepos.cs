using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChuyenNganhMonHocRepos : IChuyenNganhMonHocRepos
    {
        public HttpClient _httpClient { get; set; }

        public ChuyenNganhMonHocRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChuyenNganhMonHocs", obj);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            //if (!String.IsNullOrEmpty(searchVM.Ma))
            //    queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/ChuyenNganhMonHocs/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhMonHocVM>>(url);
            return result;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            //if (!String.IsNullOrEmpty(searchVM.NgayTao))
            //    queryStringParam.Add("TrangThai", searchVM.TrangThai);

            //....
            string url = QueryHelpers.AddQueryString("/api/ChuyenNganhMonHocs/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhMonHocVM>>(url);
            return result;
        }

        public async Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var result = await _httpClient.GetFromJsonAsync<ChuyenNganhMonHocVM>($"/api/ChuyenNganhMonHocs/all/{idChuyenNganh},{idMonHoc}");
            return result;
        }

        public async Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var url = Path.Combine("/api/ChuyenNganhMonHocs", idChuyenNganh.ToString(), idMonHoc.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
