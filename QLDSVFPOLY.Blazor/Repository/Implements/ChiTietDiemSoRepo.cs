using Microsoft.AspNetCore.WebUtilities;
using QLDSVFPOLY.Blazor.Repository.Interfaces;
using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;

namespace QLDSVFPOLY.Blazor.Repository.Implements
{
    public class ChiTietDiemSoRepo : IChiTietDiemSoRepo
    {
        HttpClient _httpClient;
        public ChiTietDiemSoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietDiemSoVM> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj)
        {
            throw new NotImplementedException();
        }
    }
}
