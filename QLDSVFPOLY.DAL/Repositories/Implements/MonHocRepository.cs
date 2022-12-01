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
    public class MonHocRepository : IMonHocRepository
    {
        QLSVDbContext _dbContext;
        public MonHocRepository()
        {
            _dbContext = new QLSVDbContext();
        }
        //async await: lập trình bất đồng bộ
        //Xóa + Sửa
        //Cancellation token

        //Thêm > SaveChanges
        //Lưu thay đổi
        public async Task<MonHoc> CreateAsync(MonHoc obj)
        {
            return (await _dbContext.MonHocs.AddAsync(obj)).Entity;
        }

        public async Task<List<MonHoc>> GetAllAsync()
        {
            return await Task.FromResult(_dbContext.MonHocs.ToList());
        }

        public async Task<MonHoc> RemoveAsync(Guid id)
        {
            var obj = _dbContext.MonHocs.FirstOrDefault(c => c.Id == id);
            return await(Task.FromResult(_dbContext.MonHocs.Remove(obj).Entity));
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MonHoc> UpdateAsync(MonHoc obj)
        {
            return await (Task.FromResult(_dbContext.MonHocs.Update(obj).Entity));
        }
        
    }
}
