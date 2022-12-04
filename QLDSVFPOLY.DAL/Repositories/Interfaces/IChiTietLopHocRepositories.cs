using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IChiTietLopHocRepositories
    {
        Task<List<ChiTietLopHoc>> GetAllAsync();

        Task<ChiTietLopHoc> CreateAsync(ChiTietLopHoc obj);
        Task<ChiTietLopHoc> UpdateAsync(ChiTietLopHoc obj);
        Task<ChiTietLopHoc> RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
