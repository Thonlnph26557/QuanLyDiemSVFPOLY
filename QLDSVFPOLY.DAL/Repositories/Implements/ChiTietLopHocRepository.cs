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
    public class ChiTietLopHocRepository : IChiTietLopHocRepository
    {
        //
        QLSVDbContext _qlsvDbContext;

        //
        public ChiTietLopHocRepository()
        {
            _qlsvDbContext = new QLSVDbContext();
        }

        //
        public async Task<List<ChiTietLopHoc>> GetAllAsync()
        {
            return await Task.FromResult(_qlsvDbContext.ChiTietLopHocs.ToList());
        }

        //
        public async Task<ChiTietLopHoc> CreateAsync(ChiTietLopHoc obj)
        {
            return (await _qlsvDbContext.ChiTietLopHocs.AddAsync(obj)).Entity;
        }

        //
        public async Task<ChiTietLopHoc> UpdateAsync(ChiTietLopHoc obj)
        {
            return await(Task.FromResult(_qlsvDbContext.ChiTietLopHocs.Update(obj).Entity));
        }

        //
        public async Task<ChiTietLopHoc> RemoveAsync(Guid id)
        {
            var obj = _qlsvDbContext.ChiTietLopHocs.FirstOrDefault(c => c.Id == id);
            return await(Task.FromResult(_qlsvDbContext.ChiTietLopHocs.Remove(obj).Entity));
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
