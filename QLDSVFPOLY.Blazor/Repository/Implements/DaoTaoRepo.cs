using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class DaoTaoRepo : IDaoTaoRepo
    {
        //
        HttpClient _httpClient;

        //
        public DaoTaoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //
        public async Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM vm)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(vm.Ma))
                queryStringParam.Add("Ma", vm.Ma);

            //Add search DiaChi
            if (!String.IsNullOrEmpty(vm.DiaChi))
                queryStringParam.Add("DiaChi", vm.DiaChi);

            //Add search Email
            if (!String.IsNullOrEmpty(vm.Email))
                queryStringParam.Add("Email", vm.Email);


            //....
            string url = QueryHelpers.AddQueryString("/api/DaoTaos/all", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<DaoTaoVM>>(url);
            return result;
        }

        //
        public async Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM vm)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(vm.Ma))
                queryStringParam.Add("Ma", vm.Ma);

            //Add search DiaChi
            if (!String.IsNullOrEmpty(vm.DiaChi))
                queryStringParam.Add("DiaChi", vm.DiaChi);

            //Add search Email
            if (!String.IsNullOrEmpty(vm.Email))
                queryStringParam.Add("Email", vm.Email);


            //....
            string url = QueryHelpers.AddQueryString("/api/DaoTaos/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<DaoTaoVM>>(url);
            return result;
        }

        //
        public async Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<DaoTaoVM>($"/api/DaoTaos/{id}");
            return result;
        }

        //
        public async Task<bool> CreateAsync(DaoTaoCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/DaoTaos", vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        //
        public async Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM vm)
        {
            var url = Path.Combine("/api/DaoTaos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }

        //
        public async Task<bool> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/DaoTaos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return true;
            return false;
        }
    }
}
