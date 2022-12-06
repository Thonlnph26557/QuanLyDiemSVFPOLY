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
    public class NhanVienDaoTaoRepository : INhanVienDaoTaoRepository
    {
        QLSVDbContext _dbContext;
        public NhanVienDaoTaoRepository()
        {
            _dbContext = new QLSVDbContext();
        }
        //async await: lập trình bất đồng bộ
        public async Task<NhanVienDaoTao> CreateAsync(NhanVienDaoTao obj)
        {
            return (await _dbContext.NhanVienDaoTaos.AddAsync(obj)).Entity;
        }

        public async Task<List<NhanVienDaoTao>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.NhanVienDaoTaos.ToList());
        }

        public async Task<NhanVienDaoTao> RemoveAsync(Guid id)
        {
            var obj = _dbContext.NhanVienDaoTaos.FirstOrDefault(c => c.Id == id);
            return await (Task.FromResult(_dbContext.NhanVienDaoTaos.Remove(obj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NhanVienDaoTao> UpdateAsync(NhanVienDaoTao obj)
        {
            return await (Task.FromResult(_dbContext.NhanVienDaoTaos.Update(obj).Entity));
        }
    }
}
