using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface INhanVienDaoTaoRepository
    {
        Task<List<NhanVienDaoTao>> GetAllAsync();
        Task<NhanVienDaoTao> CreateAsync(NhanVienDaoTao obj);
        Task<NhanVienDaoTao> UpdateAsync(NhanVienDaoTao obj);
        Task<NhanVienDaoTao> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
