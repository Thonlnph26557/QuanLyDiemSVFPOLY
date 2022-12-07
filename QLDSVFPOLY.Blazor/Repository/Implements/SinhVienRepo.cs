﻿using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class SinhVienRepos : ISinhVienRepos
    {
        //
        HttpClient _httpClient;

        //
        public SinhVienRepos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //
        public async Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM vm)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(vm.Ma))
                queryStringParam.Add("Ma", vm.Ma);

            //Add search Ho
            if (!String.IsNullOrEmpty(vm.Ho))
                queryStringParam.Add("Ho", vm.Ho);

            //Add search TenDem
            if (!String.IsNullOrEmpty(vm.TenDem))
                queryStringParam.Add("TenDem", vm.TenDem);

            //Add search Ten
            if (!String.IsNullOrEmpty(vm.Ten))
                queryStringParam.Add("Ten", vm.Ten);

            //Add search DiaChi
            if (!String.IsNullOrEmpty(vm.DiaChi))
                queryStringParam.Add("DiaChi", vm.DiaChi);

            //Add search SoDienThoai
            if (!String.IsNullOrEmpty(vm.SoDienThoai))
                queryStringParam.Add("SoDienThoai", vm.SoDienThoai);

            //Add search Email
            if (!String.IsNullOrEmpty(vm.Email))
                queryStringParam.Add("Email", vm.Email);

            //Add search IdChuyenNganh
            if (vm.IdChuyenNganh.HasValue)
                queryStringParam.Add("IdChuyenNganh", vm.IdChuyenNganh.ToString());


            //....
            string url = QueryHelpers.AddQueryString("/api/SinhViens/all", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<List<SinhVienVM>>(url);

            return result;
        }

        //
        public async Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM vm)
        {
            var queryStringParam = new Dictionary<string, string>();

            //Add search Mã
            if (!String.IsNullOrEmpty(vm.Ma))
                queryStringParam.Add("Ma", vm.Ma);

            //Add search Ho
            if (!String.IsNullOrEmpty(vm.Ho))
                queryStringParam.Add("Ho", vm.Ho);

            //Add search TenDem
            if (!String.IsNullOrEmpty(vm.TenDem))
                queryStringParam.Add("TenDem", vm.TenDem);

            //Add search Ten
            if (!String.IsNullOrEmpty(vm.Ten))
                queryStringParam.Add("Ten", vm.Ten);

            //Add search DiaChi
            if (!String.IsNullOrEmpty(vm.DiaChi))
                queryStringParam.Add("DiaChi", vm.DiaChi);

            //Add search SoDienThoai
            if (!String.IsNullOrEmpty(vm.SoDienThoai))
                queryStringParam.Add("SoDienThoai", vm.SoDienThoai);

            //Add search Email
            if (!String.IsNullOrEmpty(vm.Email))
                queryStringParam.Add("Email", vm.Email);

            //Add search IdChuyenNganh
            if (vm.IdChuyenNganh.HasValue)
                queryStringParam.Add("IdChuyenNganh", vm.IdChuyenNganh.ToString());


            //....
            string url = QueryHelpers.AddQueryString("/api/SinhViens/allactive", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<List<SinhVienVM>>(url);
            return result;
        }

        //
        public async Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<SinhVienVM>($"/api/SinhViens/all/{id}");
            return result;
        }

        //
        public async Task<int> CreateAsync(SinhVienCreateVM vm)
        {
            var result = await _httpClient.PostAsJsonAsync("api/SinhViens", vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        //
        public async Task<int> UpdateAsync(Guid id, SinhVienUpdateVM vm)
        {
            var url = Path.Combine("/api/SinhViens", id.ToString());
            var result = await _httpClient.PutAsJsonAsync(url, vm);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }

        //
        public async Task<int> RemoveAsync(Guid id)
        {
            var url = Path.Combine("/api/SinhViens", id.ToString());
            var result = await _httpClient.DeleteAsync(url);
            if (result.IsSuccessStatusCode) return 1;
            return 0;
        }
    }
}
