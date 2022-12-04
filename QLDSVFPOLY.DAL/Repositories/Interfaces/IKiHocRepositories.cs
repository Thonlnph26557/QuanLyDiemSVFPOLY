using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IKiHocRepositories
    {
        Task<List<KiHoc>> GetAllAsync();

        Task<KiHoc> CreateAsync(KiHoc obj);
        Task<KiHoc> UpdateAsync(KiHoc obj);
        Task<KiHoc> RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
