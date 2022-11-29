using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DTO.Entities;
using QLDSVFPOLY.DTO.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class LopHocRepositories : ILopHocRepositories
    {
        //
        QLSVDbContext _qlsvDbContext;

        //
        public LopHocRepositories()
        {
            _qlsvDbContext = new QLSVDbContext();
        }

        //async await: lập trình bất đồng bộ
        public async Task<List<LopHoc>> GetAllAsync()
        {
            return await Task.FromResult(_qlsvDbContext.LopHocs.ToList());
        }

        //
        public async Task<LopHoc> CreateAsync(LopHoc obj)
        {
            return (await _qlsvDbContext.LopHocs.AddAsync(obj)).Entity;
        }

        //
        public async Task<LopHoc> UpdateAsync(LopHoc obj)
        {
            return await(Task.FromResult(_qlsvDbContext.LopHocs.Update(obj).Entity));
        }

        //
        public async Task<LopHoc> RemoveAsync(Guid id)
        {
            var obj = _qlsvDbContext.LopHocs.FirstOrDefault(c => c.Id == id);
            return await(Task.FromResult(_qlsvDbContext.LopHocs.Remove(obj).Entity));
        }

        //
        //Xóa + Sửa
        //Cancellation token

        //Thêm > SaveChanges
        //Lưu thay đổi
        public async Task SaveChangesAsync()
        {
            await _qlsvDbContext.SaveChangesAsync();
        }
    }
}
