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
        Task<ChiTietDiemSoVM> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task<bool> CreateAsync(ChiTietDiemSoCreateVM obj);
        Task<bool> UpdateAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien, ChiTietDiemSoUpdateVM obj);
        Task<bool> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
    }
}
