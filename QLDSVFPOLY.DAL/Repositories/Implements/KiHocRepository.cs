using Microsoft.EntityFrameworkCore;
using QLDSVFPOLY.DAL.Repositories.Interfaces;
using QLDSVFPOLY.DAL.Entities;
using QLDSVFPOLY.DAL.Entities.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLDSVFPOLY.DAL.Repositories.Implements
{
    public class KiHocRepository : IKiHocRepository
    {
        //
        QLSVDbContext _qlsvDbContext;

        //
        public KiHocRepository()
        {
            _qlsvDbContext = new QLSVDbContext();
        }

        //async await: lập trình bất đồng bộ
        public async Task<List<KiHoc>> GetAllAsync()
        {
            return await Task.FromResult(_qlsvDbContext.KiHocs.ToList());
        }

        //
        public async Task<KiHoc> CreateAsync(KiHoc obj)
        {
            return (await _qlsvDbContext.KiHocs.AddAsync(obj)).Entity;
        }

        //
        public async Task<KiHoc> UpdateAsync(KiHoc obj)
        {
            return await (Task.FromResult(_qlsvDbContext.KiHocs.Update(obj).Entity));
        }

        //
        public async Task<KiHoc> RemoveAsync(Guid id)
        {
            var obj = _qlsvDbContext.KiHocs.FirstOrDefault(c => c.Id == id);
            return await (Task.FromResult(_qlsvDbContext.KiHocs.Remove(obj).Entity));
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
