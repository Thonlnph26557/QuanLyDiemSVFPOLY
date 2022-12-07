using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.DAL.Entities;
using System.Net.WebSockets;
using System.Text.Json;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class DaoTaoRepos : IDaoTaoRepos
    {
        //
        HttpClient _httpClient;

        //
        public DaoTaoRepos(HttpClient httpClient)
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

            //Add search SoDienThoai
            if (!String.IsNullOrEmpty(vm.SoDienThoai))
                queryStringParam.Add("SoDienThoai", vm.SoDienThoai);

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

            //Add search SoDienThoai
            if (!String.IsNullOrEmpty(vm.SoDienThoai))
                queryStringParam.Add("SoDienThoai", vm.SoDienThoai);

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
            var result = await _httpClient.GetFromJsonAsync<DaoTaoVM>($"/api/DaoTaos/all/{id}");
            return result;
        }

        //
        public async Task<int> CreateAsync(DaoTaoCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/DaoTaos", vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        //
        public async Task<int> UpdateAsync(Guid id, DaoTaoUpdateVM vm)
        {
            var url = Path.Combine("/api/DaoTaos", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        //
        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/DaoTaos", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
