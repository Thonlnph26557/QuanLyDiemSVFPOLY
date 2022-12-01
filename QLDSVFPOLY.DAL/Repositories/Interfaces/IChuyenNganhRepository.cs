using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IChuyenNganhRepository
    {
        Task<List<ChuyenNganh>> GetAllAsync();
        Task<ChuyenNganh> CreateAsync(ChuyenNganh obj);
        Task<ChuyenNganh> UpdateAsync(ChuyenNganh obj);
        Task<ChuyenNganh> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
