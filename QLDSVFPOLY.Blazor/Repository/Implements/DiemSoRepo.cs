using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class DiemSoRepo : IDiemSoRepo
    {
        HttpClient _httpClient;
        public DiemSoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(DiemSoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DiemSoVM>> GetAllActiveAsync(DiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<DiemSoVM>> GetAllAsync(DiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<DiemSoVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, DiemSoUpdateVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
