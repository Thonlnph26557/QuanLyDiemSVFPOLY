using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface INguoiDungRepository
    {
        Task<List<NguoiDung>> GetAllAsync();
        Task<NguoiDung> CreateAsync(NguoiDung obj);
        Task<NguoiDung> UpdateAsync(NguoiDung obj);
        Task<NguoiDung> RemoveAsync(Guid id);
        Task SaveChangesAsync();
    }
}
