using QLDSVFPOLY.DAL.Entities.EF;
using QLDSVFPOLY.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDSVFPOLY.DAL.Repositories.Interfaces;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class ChuyenNganhRepository : IChuyenNganhRepository
    {
        QLSVDbContext _dbContext;
        public ChuyenNganhRepository()
        {
            _dbContext = new QLSVDbContext();
        }

        public async Task<List<ChuyenNganh>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.ChuyenNganhs.ToList());
        }

        public async Task<ChuyenNganh> CreateAsync(ChuyenNganh obj)
        {
            return (await _dbContext.ChuyenNganhs.AddAsync(obj)).Entity;
        }

        public async Task<ChuyenNganh> RemoveAsync(Guid id)
        {
            var obj = _dbContext.ChuyenNganhs.FirstOrDefault(c => c.Id == id);
            return await (Task.FromResult(_dbContext.ChuyenNganhs.Remove(obj).Entity));
        }

        public async Task<ChuyenNganh> UpdateAsync(ChuyenNganh obj)
        {
            return await (Task.FromResult(_dbContext.ChuyenNganhs.Update(obj).Entity));
        }

        public async Task<ChuyenNganh> CreateChuyenNganhHep(ChuyenNganh obj, Guid IdChuyenNganh)
        {
            obj = new ChuyenNganh();
            obj.IdChuyenNganh = IdChuyenNganh;

            return (await _dbContext.ChuyenNganhs.AddAsync(obj)).Entity;
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
