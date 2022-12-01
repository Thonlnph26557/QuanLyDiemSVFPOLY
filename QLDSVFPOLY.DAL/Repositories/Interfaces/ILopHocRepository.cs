using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface ILopHocRepository
    {
        Task<List<LopHoc>> GetAllAsync();

        Task<LopHoc> CreateAsync(LopHoc createVm);
        Task<LopHoc> UpdateAsync(LopHoc updateVm);
        Task<LopHoc> RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
