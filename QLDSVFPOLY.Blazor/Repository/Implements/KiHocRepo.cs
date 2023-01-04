using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.KiHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class KiHocRepo : IKiHocRepo
    {
        HttpClient _httpClient;
        public KiHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(KiHocCreateViewmodel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<KiHocViewmodel>> GetAllActiveAsync(KiHocSearchViewmodel obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<KiHocViewmodel>> GetAllAsync(KiHocSearchViewmodel obj)
        {
            throw new NotImplementedException();
        }

        public Task<KiHocViewmodel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, KiHocUpdateViewmodel obj)
        {
            throw new NotImplementedException();
        }
    }
}
