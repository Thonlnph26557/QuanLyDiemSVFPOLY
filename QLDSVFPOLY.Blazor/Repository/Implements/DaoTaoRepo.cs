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

        public Task<bool> CreateAsync(DaoTaoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DaoTaoVM>> GetAllActiveAsync(DaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DaoTaoVM>> GetAllAsync(DaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<DaoTaoVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, DaoTaoUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
