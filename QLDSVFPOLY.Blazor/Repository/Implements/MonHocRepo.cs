using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganh;
using QLDSVFPOLY.BUS.ViewModels.MonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class MonHocRepo : IMonHocRepo
    {
        HttpClient _httpClient;
        public MonHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(MonHocCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<MonHocVM>> GetAllActiveAsync(MonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<MonHocVM>> GetAllAsync(MonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<MonHocVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, MonHocUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
