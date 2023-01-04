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
    public class GiangVienRepository : IGiangVienRepository
    {
        QLSVDbContext _qlsvDbContext;

        public GiangVienRepository()
        {
            _qlsvDbContext = new QLSVDbContext();
        }

        public async Task<List<GiangVien>> GetAllAsync()
        {
            return await Task.FromResult(_qlsvDbContext.GiangViens.ToList());
        }
        //
        public async Task<GiangVien> CreateAsync(GiangVien createVm)
        {
            return (await _qlsvDbContext.GiangViens.AddAsync(createVm)).Entity;
        }
        //
        public async Task<GiangVien> UpdateAsync(GiangVien updateVm)
        {
            return await (Task.FromResult(_qlsvDbContext.GiangViens.Update(updateVm).Entity));
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
