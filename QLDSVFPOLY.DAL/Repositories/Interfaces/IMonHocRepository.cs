using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IMonHocRepository
    {
        Task<List<MonHoc>> GetAllAsync();
        Task<MonHoc> CreateAsync(MonHoc obj);
        Task<MonHoc> UpdateAsync(MonHoc obj);
        Task<MonHoc> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
