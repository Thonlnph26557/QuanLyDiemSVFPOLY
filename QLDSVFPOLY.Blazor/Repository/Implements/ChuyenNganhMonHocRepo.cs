using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChuyenNganhMonHoc;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChuyenNganhMonHocRepo : IChuyenNganhMonHocRepo
    {
        public HttpClient _httpClient { get; set; }

        public ChuyenNganhMonHocRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<List<ChuyenNganhMonHocVM>> GetAllAsync(ChuyenNganhMonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChuyenNganhMonHocVM>> GetAllActiveAsync(ChuyenNganhMonHocSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChuyenNganhMonHocVM> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(ChuyenNganhMonHocCreateVM obj, Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrangThaiAsync(Guid idChuyenNganh, Guid idMonHoc)
        {
            throw new NotImplementedException();
        }
    }
}
