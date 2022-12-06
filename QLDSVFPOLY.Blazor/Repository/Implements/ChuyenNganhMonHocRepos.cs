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

        public async Task<int> CreateAsync(ChuyenNganhMonHocCreateVM obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ChuyenNganhMonHoc", obj);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        public async Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM searchVM)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            //if (!String.IsNullOrEmpty(searchVM.Ma))
            //    queryStringParam.Add("Ma", searchVM.Ma);

            //....
            string url = QueryHelpers.AddQueryString("/api/ChuyenNganhMonHoc/allactive", queryStringParam);
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
            string url = QueryHelpers.AddQueryString("/api/ChuyenNganhMonHoc/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<ChuyenNganhMonHocVM>>(url);
            return result;
        }

        public async Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var result = await _httpClient.GetFromJsonAsync<ChuyenNganhMonHocVM>($"/api/ChuyenNganhMonHoc/all/{idChuyenNganh},{idMonHoc}");
            return result;
        }

        public async Task<int> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            var url = Path.Combine("/api/ChuyenNganhMonHoc", idChuyenNganh.ToString(), idMonHoc.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
