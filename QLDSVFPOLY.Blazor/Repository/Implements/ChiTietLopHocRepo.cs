using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietLopHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChiTietLopHocRepo : IChiTietLopHocRepo
    {
        HttpClient _httpClient;
        public ChiTietLopHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(ChiTietLopHocCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietLopHocVM>> GetAllActiveAsync(ChiTietLopHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietLopHocVM>> GetAllAsync(ChiTietLopHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietLopHocVM> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid id, ChiTietLopHocUpdateVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
