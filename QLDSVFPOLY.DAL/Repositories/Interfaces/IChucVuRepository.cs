using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IChucVuRepository
    {
        Task<List<ChucVu>> GetAllAsync();
        Task<ChucVu> CreateAsync(ChucVu obj);
        Task<ChucVu> UpdateAsync(ChucVu obj);
        Task<ChucVu> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
