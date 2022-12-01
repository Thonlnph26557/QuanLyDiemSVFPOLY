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
    public class LopHocRepository : ILopHocRepository
    {
        QLSVDbContext _qlsvDbContext;

        public LopHocRepository()
        {
            _qlsvDbContext = new QLSVDbContext();
        }

        //async await: lập trình bất đồng bộ
        public async Task<List<LopHoc>> GetAllAsync()
        {
            return await Task.FromResult(_qlsvDbContext.LopHocs.ToList());
        }

        //
        public async Task<LopHoc> CreateAsync(LopHoc createVm)
        {
            return (await _qlsvDbContext.LopHocs.AddAsync(createVm)).Entity;
        }

        //
        public async Task<LopHoc> UpdateAsync(LopHoc updateVm)
        {
            return await (Task.FromResult(_qlsvDbContext.LopHocs.Update(updateVm).Entity));
        }

        //
        public async Task<LopHoc> RemoveAsync(Guid id)
        {
            var obj = _qlsvDbContext.LopHocs.FirstOrDefault(c => c.Id == id);
            return await (Task.FromResult(_qlsvDbContext.LopHocs.Remove(obj).Entity));
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
