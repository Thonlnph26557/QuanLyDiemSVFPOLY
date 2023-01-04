using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using System.Net.Http.Json;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChuyenNganhRepo : IChuyenNganhRepo
    {
        HttpClient _httpClient;

        public ChuyenNganhRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(ChuyenNganhCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhVM>> GetAllActiveAsync(ChuyenNganhSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhVM>> GetAllAsync(ChuyenNganhSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChuyenNganhVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhVM>> GetChuyenNganhHepById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, ChuyenNganhUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
