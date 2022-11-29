using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IGiangVienRepositories
    {
        Task<List<GiangVien>> GetAllAsync();

        Task<GiangVien> CreateAsync(GiangVien obj);
        Task<GiangVien> UpdateAsync(GiangVien obj);
        Task<GiangVien> RemoveAsync(Guid id);

        Task SaveChangesAsync();
    }
}
