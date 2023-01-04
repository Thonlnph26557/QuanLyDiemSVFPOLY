using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IChiTietDiemSoRepository
    {
        Task<ChiTietDiemSo> CreateAsync(ChiTietDiemSo obj);
        Task<ChiTietDiemSo> UpdateAsync(ChiTietDiemSo obj);
        Task<ChiTietDiemSo> DeleteAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task<List<ChiTietDiemSo>> GetAllChiTietDiemSoAsync();
        Task<ChiTietDiemSo> GetByIdAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task SaveChangesAsync();
    }
}
