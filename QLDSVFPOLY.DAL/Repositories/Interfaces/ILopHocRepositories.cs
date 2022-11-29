using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface ILopHocRepositories
    {
        Task<List<LopHoc>> GetAllAsync();

        Task<LopHoc> CreateAsync(LopHoc obj);
        Task<LopHoc> UpdateAsync(LopHoc obj);
        Task<LopHoc> RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
