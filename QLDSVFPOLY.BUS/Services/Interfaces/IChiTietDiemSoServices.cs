using QLDSVFPOLY.BUS.ViewModels.ChiTietDiemSo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.BUS.Services.Interfaces
{
    public interface IChiTietDiemSoServices
    {
        Task<List<ChiTietDiemSoVM>> GetAllAsync(ChiTietDiemSoSearchVM obj);
        Task<List<ChiTietDiemSoVM>> GetAllActiveAsync(ChiTietDiemSoSearchVM obj);
        Task<ChiTietDiemSoVM> GetByIdAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo);
        Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj);
        Task<bool> UpdateAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo, ChiTietDiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo);
        Task<bool> RemoveByUpdateAsync(Guid idCTLH, Guid idSinhVien, Guid idDiemSo);
    }
}
