using QLDSVFPOLY.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface ISinhVienRepository
    {
        Task<List<SinhVien>> GetAllAsync();
        Task<SinhVien> CreateAsync(SinhVien obj);
        Task<SinhVien> UpdateAsync(SinhVien obj);
        Task<SinhVien> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
