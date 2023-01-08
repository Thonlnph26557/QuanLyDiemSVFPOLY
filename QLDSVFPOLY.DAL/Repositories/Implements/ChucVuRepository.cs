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
    public class ChucVuRepository : IChucVuRepository
    {
        QLSVDbContext _dbContext;
        public ChucVuRepository()
        {
            _dbContext = new QLSVDbContext();
        }
        public async Task<ChucVu> CreateAsync(ChucVu obj)
        {
            return (await _dbContext.ChucVus.AddAsync(obj)).Entity;
        }

        public async Task<List<ChucVu>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.ChucVus.ToList());
        }

        public async Task<ChucVu> RemoveAsync(Guid id)
        {
            var obj = _dbContext.ChucVus.FirstOrDefault(c => c.Id == id);
            return await(Task.FromResult(_dbContext.ChucVus.Remove(obj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ChucVu> UpdateAsync(ChucVu obj)
        {
            return await(Task.FromResult(_dbContext.ChucVus.Update(obj).Entity));
        }
    }
}
