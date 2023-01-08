using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Entities.EF;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class NguoiDungChucVuRepository : INguoiDungChucVuRepository
    {
        QLSVDbContext _dbContext;
        public NguoiDungChucVuRepository()
        {
            _dbContext = new QLSVDbContext();
        }
        public async Task<NguoiDungChucVu> CreateAsync(NguoiDungChucVu obj)
        {
            await _dbContext.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<NguoiDungChucVu> DeleteAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var tempobj = _dbContext.NguoiDungChucVus.FirstOrDefault(c => c.IdNguoiDung == idNguoiDung
                                                                 && c.IdChucVu == idChucVu);
            _dbContext.Remove(tempobj);
            await _dbContext.SaveChangesAsync();
            return tempobj;
        }

        public async Task<List<NguoiDungChucVu>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.NguoiDungChucVus.ToList());
        }

        public async Task<NguoiDungChucVu> GetByIdAsync(Guid idNguoiDung, Guid idChucVu)
        {
            var tempobj = await _dbContext.NguoiDungChucVus.FirstOrDefaultAsync(c => c.IdNguoiDung == idNguoiDung
                                                                 && c.IdChucVu == idChucVu);
            return tempobj;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NguoiDungChucVu> UpdateAsync(NguoiDungChucVu obj)
        {
            return await (Task.FromResult(_dbContext.NguoiDungChucVus.Update(obj).Entity));
        }
    }
}
