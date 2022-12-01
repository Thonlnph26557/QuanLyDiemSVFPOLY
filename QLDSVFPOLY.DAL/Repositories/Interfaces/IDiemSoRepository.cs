using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface IDiemSoRepository
    {
        Task<DiemSo> CreateAsync(DiemSo obj);
        Task<DiemSo> UpdateAsync(DiemSo obj);
        Task<DiemSo> DeleteAsync(Guid id);
        Task<List<DiemSo>> GetAllDiemSoAsync();
        Task<DiemSo> GetById(Guid id);
        Task SaveChangesAsync();
    }
}
