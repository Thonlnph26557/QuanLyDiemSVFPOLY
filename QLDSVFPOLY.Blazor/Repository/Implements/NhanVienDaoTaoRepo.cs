using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.NhanVienDaoTao;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class NhanVienDaoTaoRepo : INhanVienDaoTaoRepo
    {
        HttpClient _httpClient;
        public NhanVienDaoTaoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(NhanVienDaoTaoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<NhanVienDaoTaoVM>> GetAllActiveAsync(NhanVienDaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<NhanVienDaoTaoVM>> GetAllAsync(NhanVienDaoTaoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<NhanVienDaoTaoVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, NhanVienDaoTaoUpdateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
