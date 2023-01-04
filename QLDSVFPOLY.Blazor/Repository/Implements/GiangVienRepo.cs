using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.GiangVien;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class GiangVienRepo : IGiangVienRepo
    {
        public HttpClient _httpClient { get; set; }

        public GiangVienRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<GiangVienVM>> GetAllAsync(GiangVienSearchVM searchVm)
        {
            throw new NotImplementedException();
        }

        public Task<List<GiangVienVM>> GetAllActiveAsync(GiangVienSearchVM searchVm)
        {
            throw new NotImplementedException();
        }

        public Task<GiangVienVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(GiangVienCreateVM createVm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, GiangVienUpdateVM updateVm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrangThaiAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
