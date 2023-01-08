using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Interfaces
{
    public interface INguoiDungChucVuRepository
    {
        Task<List<NguoiDungChucVu>> GetAllAsync();
        Task<NguoiDungChucVu> GetByIdAsync(Guid idNguoiDung, Guid idChucVu);
        Task<NguoiDungChucVu> CreateAsync(NguoiDungChucVu obj);
        Task<NguoiDungChucVu> UpdateAsync(NguoiDungChucVu obj);
        Task<NguoiDungChucVu> DeleteAsync(Guid idNguoiDung, Guid idChucVu);

        Task SaveChangesAsync();
    }
}
