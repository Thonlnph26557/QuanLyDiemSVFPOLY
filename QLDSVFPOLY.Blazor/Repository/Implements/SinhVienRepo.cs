using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.DaoTao;
using QLDSVFPOLY.BUS.ViewModels.SinhVien;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class SinhVienRepo : ISinhVienRepo
    {
        //
        HttpClient _httpClient;

        //
        public SinhVienRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(SinhVienCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<SinhVienVM>> GetAllActiveAsync(SinhVienSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<SinhVienVM>> GetAllAsync(SinhVienSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<SinhVienVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, SinhVienUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
