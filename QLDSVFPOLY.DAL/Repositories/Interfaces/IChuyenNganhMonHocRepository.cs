using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IChuyenNganhMonHocRepository
    {
        Task<ChuyenNganhMonHoc> CreateAsync(ChuyenNganhMonHoc obj);
        Task<ChuyenNganhMonHoc> UpdateAsync(ChuyenNganhMonHoc obj);
        Task<ChuyenNganhMonHoc> DeleteAsync(Guid idChuyenNganh, Guid idMonHoc);
        Task<List<ChuyenNganhMonHoc>> GetAllAsync();
        Task<ChuyenNganhMonHoc> GetByIdAsync(Guid idChuyenNganh, Guid idMonHoc);
        Task SaveChangesAsync();
    }
}
