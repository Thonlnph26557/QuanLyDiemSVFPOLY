using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class SinhVienRepository : ISinhVienRepository
    {
        QLSVDbContext _dbContext;
        public SinhVienRepository()
        {
            _dbContext = new QLSVDbContext();
        }

        public async Task<SinhVien> CreateAsync(SinhVien obj)
        {
            return (await _dbContext.SinhViens.AddAsync(obj)).Entity;
        }

        public async Task<List<SinhVien>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.SinhViens.ToList());
        }

        public async Task<SinhVien> RemoveAsync(Guid id)
        {
            var obj = _dbContext.SinhViens.FirstOrDefault(c => c.Id == id);
            return await(Task.FromResult(_dbContext.SinhViens.Remove(obj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SinhVien> UpdateAsync(SinhVien obj)
        {
            return await(Task.FromResult(_dbContext.SinhViens.Update(obj).Entity));
        }
    }
}
