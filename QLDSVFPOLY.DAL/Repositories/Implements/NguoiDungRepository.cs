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
    public class NguoiDungRepository : INguoiDungRepository
    {
        QLSVDbContext _dbContext;
        public NguoiDungRepository()
        {
            _dbContext = new QLSVDbContext();
        }
        public async Task<NguoiDung> CreateAsync(NguoiDung obj)
        {
            return (await _dbContext.NguoiDungs.AddAsync(obj)).Entity;
        }

        public async Task<List<NguoiDung>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.NguoiDungs.ToList());
        }

        public async Task<NguoiDung> RemoveAsync(Guid id)
        {
            var obj = _dbContext.NguoiDungs.FirstOrDefault(c => c.Id == id);
            return await(Task.FromResult(_dbContext.NguoiDungs.Remove(obj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NguoiDung> UpdateAsync(NguoiDung obj)
        {
            return await(Task.FromResult(_dbContext.NguoiDungs.Update(obj).Entity));
        }
    }
}
