using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IGiangVienRepository
    {
        Task<List<GiangVien>> GetAllAsync();

        Task<GiangVien> CreateAsync(GiangVien createVm);
        Task<GiangVien> UpdateAsync(GiangVien updateVm);
        Task<GiangVien> RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
