using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DTO.Entities;
using QLDSVFPOLY.DTO.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class GiangVienRepositories : IGiangVienRepositories
    {
        QLSVDbContext _qlsvDbContext;

        public GiangVienRepositories()
        {
            _qlsvDbContext = new QLSVDbContext();
        }
        //async await: lập trình bất đồng bộ
        public async Task<List<GiangVien>> GetAllAsync()
        {
            return await Task.FromResult(_qlsvDbContext.GiangViens.ToList());
        }
        //
        public async Task<GiangVien> CreateAsync(GiangVien obj)
        {
            return (await _qlsvDbContext.GiangViens.AddAsync(obj)).Entity;
        }
        //
        public async Task<GiangVien> UpdateAsync(GiangVien obj)
        {
            return await (Task.FromResult(_qlsvDbContext.GiangViens.Update(obj).Entity));
        }
        //
        public async Task<GiangVien> RemoveAsync(Guid id)
        {
            var obj = _qlsvDbContext.GiangViens.FirstOrDefault(c => c.Id == id);
            return await (Task.FromResult(_qlsvDbContext.GiangViens.Remove(obj).Entity));
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
