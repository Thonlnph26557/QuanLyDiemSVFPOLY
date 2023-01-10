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
        Task<List<ChiTietDiemSo>> GetAllAsync();
        Task<ChiTietDiemSo> CreateAsync(ChiTietDiemSo obj);
        Task<ChiTietDiemSo> UpdateAsync(ChiTietDiemSo obj);
        Task<ChiTietDiemSo> RemoveAsync(Guid idDiemSo, Guid idLopHoc, Guid idSinhVien);
        Task SaveChangesAsync();
    }
}
