using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IDaoTaoRepository
    {
        Task<List<DaoTao>> GetAllAsync();
        Task<DaoTao> CreateAsync(DaoTao obj);
        Task<DaoTao> UpdateAsync(DaoTao obj);
        Task<DaoTao> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
