using Microsoft.EntityFrameworkCore.Migrations.Operations;
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
    public class DaoTaoRepository : IDaoTaoRepository
    {
        QLSVDbContext _dbContext;
        public DaoTaoRepository()
        {
            _dbContext = new QLSVDbContext();
        }
        //async await: lập trình bất đồng bộ

        public async Task<List<DaoTao>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.DaoTaos.ToList());
        }

        public async Task<DaoTao> CreateAsync(DaoTao obj)
        {
            return (await _dbContext.DaoTaos.AddAsync(obj)).Entity;
        }

        public async Task<DaoTao> RemoveAsync(Guid id)
        {
            var obj = _dbContext.DaoTaos.FirstOrDefault(c => c.Id == id);
            return await (Task.FromResult(_dbContext.DaoTaos.Remove(obj).Entity));
        }

        public async Task<DaoTao> UpdateAsync(DaoTao obj)
        {
            return await (Task.FromResult(_dbContext.DaoTaos.Update(obj).Entity));
        }

        //Xóa + Sửa
        //Cancellation token

        //Thêm > SaveChanges
        //Lưu thay đổi
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
